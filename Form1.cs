using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
//using Toupcam;
using System.Text;
using System.Text.RegularExpressions;

namespace Hwaseung
{
    public partial class Form1 : Form
    {
        private sealed class DefectResult
        {
            public string DefectName { get; set; } = string.Empty;
            public Rectangle DefectRect { get; set; }
            public Bitmap? CropImage { get; set; }
        }

        private Toupcam _cam = null;
        private Toupcam.DelegateEventCallback _cameraCallback = null;
        private VideoCapture? _uvcCap = null;
        private CancellationTokenSource? _uvcCts = null;
        private Task? _uvcTask = null;
        private Bitmap _currentFrame = null;
        private readonly object _lockObj = new object();
        private bool _isUpdatingSettingsUi = false;
        public Form1()
        {
            InitializeComponent();
        }
        // 1. Nút kết nối và mở live camera
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_cam != null) return;

            // Quét các camera ToupTek / XCAM đang cắm qua USB
            Toupcam.DeviceV2[] devices;
            try
            {
                devices = EnumerateCamerasWithRetry();
            }
            catch (DllNotFoundException ex)
            {
                ShowNativeLibraryLoadError(ex);
                return;
            }
            catch (BadImageFormatException)
            {
                MessageBox.Show(
                    "Không thể nạp thư viện toupcam.dll do sai kiến trúc (x86/x64).\n" +
                    "Hãy chạy ứng dụng ở x64 và dùng đúng bản SDK x64.",
                    "Lỗi nạp thư viện camera",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (devices.Length == 0)
            {
                Toupcam fallbackCam = null;
                try
                {
                    fallbackCam = Toupcam.OpenByIndex(0);
                }
                catch
                {
                    // Ignore and report below.
                }

                if (fallbackCam != null)
                {
                    _cam = fallbackCam;
                }
                else
                {
                    if (TryStartUvcCamera())
                    {
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                        btnCapture.Enabled = true;
                        MessageBox.Show("Đã mở camera theo chế độ UVC (DirectShow), không dùng SDK Toupcam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var report = BuildCameraDiagnosticReport();
                MessageBox.Show(
                    "Không tìm thấy Camera XCAM/ToupTek qua cổng USB.\n\n" +
                    "Vui lòng kiểm tra:\n" +
                    "1) Camera đã được cấp nguồn và đèn trạng thái hoạt động.\n" +
                    "2) Đã cài đúng driver của hãng camera.\n" +
                    "3) Thử đổi cổng USB/cáp USB khác.\n" +
                    "4) Đóng các ứng dụng khác đang chiếm camera.\n" +
                    "5) Nếu đang dùng chính sách bảo mật doanh nghiệp, kiểm tra quyền truy cập USB/camera.\n\n" +
                    report,
                    "Không tìm thấy camera",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
                }
            }

            // Mở camera đầu tiên tìm thấy
            if (_cam == null)
            {
                _cam = Toupcam.Open(devices[0].id);
            }

            if (_cam != null)
            {
                // Cấu hình tính năng phơi sáng tự động (Auto Exposure) = False
                // CHÚ Ý: Trong nhà xưởng kiểm tra FPCB bằng AI, BẮT BUỘC tắt Auto Exposure để độ sáng cố định
                _cam.put_AutoExpoEnable(false);
                _cam.put_ExpoTime(20000); // Thời gian phơi sáng: 20,000 microsecond (20ms) - Tùy chỉnh theo đèn xưởng
                _cam.put_ExpoAGain(100);  // Gain = 100%

                // Keep the delegate in a field so GC won't collect it while native code holds the pointer
                _cameraCallback = new Toupcam.DelegateEventCallback(OnCameraEvent);
                // Bắt đầu chế độ Pull Mode với callback nhận khung hình
                _cam.StartPullModeWithCallback(_cameraCallback);

                LoadCameraSettingsToUi();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnCapture.Enabled = true;
            }
        }

        private static string BuildCameraDiagnosticReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("--- Diagnostic ---");
            sb.AppendLine($"Process architecture: {(Environment.Is64BitProcess ? "x64" : "x86")}");
            sb.AppendLine($"OS architecture: {(Environment.Is64BitOperatingSystem ? "x64" : "x86")}");

            try
            {
                sb.AppendLine($"Toupcam.Version: {Toupcam.Version()}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"Toupcam.Version error: {ex.Message}");
            }

            try
            {
                var e1 = Toupcam.EnumV2();
                sb.AppendLine($"EnumV2 count: {e1.Length}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"EnumV2 error: {ex.Message}");
            }

            try
            {
                var e2 = Toupcam.EnumWithName();
                sb.AppendLine($"EnumWithName count: {e2.Length}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"EnumWithName error: {ex.Message}");
            }

            return sb.ToString();
        }

        private static Toupcam.DeviceV2[] EnumerateCamerasWithRetry()
        {
            // Một số camera USB cần thêm thời gian khởi tạo sau khi cắm cáp.
            const int maxRetry = 5;
            const int delayMs = 300;

            for (int i = 0; i < maxRetry; i++)
            {
                var devices = Toupcam.EnumV2();
                if (devices.Length > 0)
                    return devices;

                // Fallback API của SDK
                devices = Toupcam.EnumWithName();
                if (devices.Length > 0)
                    return devices;

                if (i < maxRetry - 1)
                    Thread.Sleep(delayMs);
            }

            return Array.Empty<Toupcam.DeviceV2>();
        }

        private bool TryStartUvcCamera()
        {
            for (int i = 0; i < 8; i++)
            {
                var cap = new VideoCapture(1, VideoCaptureAPIs.DSHOW);
                if (!cap.IsOpened())
                {
                    cap.Dispose();
                    continue;
                }

                _uvcCap = cap;
                _uvcCts = new CancellationTokenSource();
                _uvcTask = Task.Run(() => RunUvcLoop(_uvcCts.Token));
                return true;
            }

            return false;
        }
        VideoCapture capture = new VideoCapture(1);
        //private VideoCapture capture;
        private Mat frame;
        private void camera_test(object sender, EventArgs e)
        {
            // Index 0 = Webcam Laptop, Index 1 = XCAM1080P2MPA
            

            // Đặt độ phân giải Full HD 1080p
            capture.Set(VideoCaptureProperties.FrameWidth, 1920);
            capture.Set(VideoCaptureProperties.FrameHeight, 1080);

            if (capture.IsOpened())
            {
                frame = new Mat();
                Application.Idle += ProcessFrame; // Chạy luồng đọc ảnh liên tục
            }
            else
            {
                MessageBox.Show("Không thể kết nối XCam 1080p!");
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (capture != null && capture.IsOpened())
            {
                capture.Read(frame);
                if (!frame.Empty())
                {
                    // Hiển thị khung hình lên PictureBox trong WinForms
                    pictureBox1.Image = BitmapConverter.ToBitmap(frame);
                }
            }
        }

        private void RunUvcLoop(CancellationToken token)
        {
            using var frame = new Mat();

            while (!token.IsCancellationRequested)
            {
                if (_uvcCap == null || !_uvcCap.IsOpened())
                    break;

                if (!_uvcCap.Read(frame) || frame.Empty())
                {
                    Thread.Sleep(10);
                    continue;
                }

                using Bitmap bmp = BitmapConverter.ToBitmap(frame);
                Bitmap latestFrame = (Bitmap)bmp.Clone();
                Bitmap uiFrame = (Bitmap)bmp.Clone();

                lock (_lockObj)
                {
                    _currentFrame?.Dispose();
                    _currentFrame = latestFrame;
                }

                try
                {
                    BeginInvoke(new Action(() =>
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = uiFrame;
                    }));
                }
                catch
                {
                    uiFrame.Dispose();
                    break;
                }
            }
        }

        private void StopUvcCamera()
        {
            if (_uvcCts != null)
            {
                _uvcCts.Cancel();
                try
                {
                    _uvcTask?.Wait(500);
                }
                catch { }
                _uvcCts.Dispose();
                _uvcCts = null;
            }

            _uvcTask = null;

            if (_uvcCap != null)
            {
                _uvcCap.Release();
                _uvcCap.Dispose();
                _uvcCap = null;
            }
        }

        // 2. Hàm callback xử lý sự kiện từ camera (chạy dưới dạng native thread)
        private void OnCameraEvent(Toupcam.eEVENT evt)
        {
            // Sự kiện khi camera vừa chụp hoàn tất 1 khung hình mới
            if (evt == Toupcam.eEVENT.EVENT_IMAGE)
            {
                PullAndRenderFrame();
            }
        }

        // 3. Lấy dữ liệu bộ đệm và hiển thị lên PictureBox
        private void PullAndRenderFrame()
        {
            if (_cam == null) return;

            // Lấy kích thước ảnh hiện tại của camera
            _cam.get_Size(out int width, out int height);

            // Tạo Bitmap để chứa dữ liệu ảnh RGB24
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            // Rút dữ liệu ảnh từ bộ đệm của camera vào Bitmap
            Toupcam.FrameInfoV4 info = new Toupcam.FrameInfoV4();
            bool success = _cam.PullImage(bmpData.Scan0, 0, 24, 0, out info);
            bmp.UnlockBits(bmpData);

            if (success)
            {
                lock (_lockObj)
                {
                    _currentFrame?.Dispose();
                    _currentFrame = (Bitmap)bmp.Clone();
                }

                // Cập nhật giao diện UI một cách bất đồng bộ bằng BeginInvoke
                this.BeginInvoke(new Action(() =>
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = bmp;
                }));
            }
            else
            {
                bmp.Dispose();
            }
        }

        // 4. Nút chụp ảnh để đưa vào mô hình AI
        private void btnCapture_Click(object sender, EventArgs e)
        {
            Bitmap capturedFrame = null;

            lock (_lockObj)
            {
                if (_currentFrame != null)
                {
                    // Copy ra một bản sao hoàn chỉnh để tránh xung đột bộ nhớ khi Live đang ch chạy
                    capturedFrame = (Bitmap)_currentFrame.Clone();
                }
            }

            if (capturedFrame != null)
            {
                // TODO: Truyền 'capturedFrame' này vào hàm xử lý AI của bạn
                // Ví dụ: DetectFpcbDefectsWithAI(capturedFrame);
                // Kết quả detect nên gọi: RenderDefectResults(results);

                // Lưu thử ảnh ra để kiểm tra
                string filePath = $"FPCB_Inspection_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                capturedFrame.Save(filePath, ImageFormat.Png);
                capturedFrame.Dispose();

                MessageBox.Show($"Đã chụp và lưu ảnh kiểm tra: {filePath}", "Thành công");
            }
        }

        // 5. Nút ngắt kết nối camera
        private void btnStop_Click(object sender, EventArgs e)
        {
            CloseCamera();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnCapture.Enabled = false;
        }

        private void CloseCamera()
        {
            if (_cam != null)
            {
                _cam.Close();
                _cam = null;
            }

            StopUvcCamera();

            // release managed reference to the delegate so it can be GC'd
            _cameraCallback = null;

            lock (_lockObj)
            {
                _currentFrame?.Dispose();
                _currentFrame = null;
            }

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            ClearDefectResultsGrid();
            MessageBox.Show($"Stop camera Thành công");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCamera();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            trackBrightness.Minimum = Toupcam.BRIGHTNESS_MIN;
            trackBrightness.Maximum = Toupcam.BRIGHTNESS_MAX;
            trackBrightness.Value = Toupcam.BRIGHTNESS_DEF;

            trackContrast.Minimum = Toupcam.CONTRAST_MIN;
            trackContrast.Maximum = Toupcam.CONTRAST_MAX;
            trackContrast.Value = Toupcam.CONTRAST_DEF;

            trackSharpness.Minimum = Toupcam.SHARPENING_STRENGTH_MIN;
            trackSharpness.Maximum = Toupcam.SHARPENING_STRENGTH_MAX;
            trackSharpness.Value = Toupcam.SHARPENING_STRENGTH_DEF;

            nudExposure.Minimum = 100;
            nudExposure.Maximum = 1000000;
            nudExposure.Value = 20000;

            nudGain.Minimum = Toupcam.EXPOGAIN_MIN;
            nudGain.Maximum = 800;
            nudGain.Value = Toupcam.EXPOGAIN_DEF;

            UpdateSettingValueLabels();

            btnStop.Enabled = true;
            btnCapture.Enabled = true;
        }

        private void trackBrightness_Scroll(object sender, EventArgs e)
        {
            UpdateSettingValueLabels();
            TryAutoApplySettings();
        }

        private void trackContrast_Scroll(object sender, EventArgs e)
        {
            UpdateSettingValueLabels();
            TryAutoApplySettings();
        }

        private void trackSharpness_Scroll(object sender, EventArgs e)
        {
            UpdateSettingValueLabels();
            TryAutoApplySettings();
        }

        private void nudExposure_ValueChanged(object sender, EventArgs e)
        {
            UpdateSettingValueLabels();
            TryAutoApplySettings();
        }

        private void nudGain_ValueChanged(object sender, EventArgs e)
        {
            UpdateSettingValueLabels();
            TryAutoApplySettings();
        }

        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            ApplyCameraSettings(true);
        }

        private void btnReadSettings_Click(object sender, EventArgs e)
        {
            LoadCameraSettingsToUi();
        }

        private void ShowNativeLibraryLoadError(DllNotFoundException ex)
        {
            var hint =
                "Không thể nạp toupcam.dll hoặc dependency của nó.\n\n" +
                "Nguyên nhân phổ biến:\n" +
                "1) DLL bị Application Control chặn (mã lỗi 4551 / 0x800711C7).\n" +
                "2) Sai kiến trúc DLL (x86/x64).\n" +
                "3) Thiếu VC++ runtime phụ thuộc.\n\n" +
                "Cách xử lý nhanh:\n" +
                "- Mở PowerShell (Run as Administrator) và chạy: Get-ChildItem -Recurse | Unblock-File\n" +
                "- Đảm bảo chạy cấu hình x64 và dùng toupcam.dll bản x64.\n" +
                "- Nếu máy có AppLocker/WDAC, cần whitelist toupcam.dll theo chính sách IT.\n\n" +
                $"Chi tiết lỗi: {ex.Message}";

            MessageBox.Show(hint, "Lỗi nạp thư viện camera", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TryAutoApplySettings()
        {
            if (_isUpdatingSettingsUi) return;
            if (!chkAutoApply.Checked) return;
            ApplyCameraSettings(false);
        }

        private void UpdateSettingValueLabels()
        {
            lblBrightnessValue.Text = trackBrightness.Value.ToString();
            lblContrastValue.Text = trackContrast.Value.ToString();
            lblSharpnessValue.Text = trackSharpness.Value.ToString();
            lblExposureValue.Text = $"{nudExposure.Value} µs";
            lblGainValue.Text = $"{nudGain.Value}%";
        }

        private bool ApplyCameraSettings(bool showMessage)
        {
            if (_cam == null)
            {
                if (showMessage)
                    MessageBox.Show("Camera chưa kết nối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            bool ok = true;
            ok &= _cam.put_Brightness(trackBrightness.Value);
            ok &= _cam.put_Contrast(trackContrast.Value);

            int sharpnessOption = (Toupcam.SHARPENING_THRESHOLD_DEF << 24)
                                  | (Toupcam.SHARPENING_RADIUS_DEF << 16)
                                  | trackSharpness.Value;
            ok &= _cam.put_Option(Toupcam.eOPTION.OPTION_SHARPENING, sharpnessOption);

            ok &= _cam.put_ExpoTime((uint)nudExposure.Value);
            ok &= _cam.put_ExpoAGain((ushort)nudGain.Value);

            if (showMessage)
            {
                if (ok)
                    MessageBox.Show("Đã áp dụng thông số camera.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Áp dụng thất bại. HResult: {_cam.HResult} - {Toupcam.HResult2String(_cam.HResult)}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ok;
        }

        private void LoadCameraSettingsToUi()
        {
            if (_cam == null)
            {
                UpdateSettingValueLabels();
                return;
            }

            _isUpdatingSettingsUi = true;
            try
            {
                if (_cam.get_ExpTimeRange(out uint expoMin, out uint expoMax, out uint expoDef))
                {
                    nudExposure.Minimum = expoMin;
                    nudExposure.Maximum = expoMax;
                    if (nudExposure.Value < nudExposure.Minimum || nudExposure.Value > nudExposure.Maximum)
                        nudExposure.Value = expoDef;
                }

                if (_cam.get_ExpoAGainRange(out ushort gainMin, out ushort gainMax, out ushort gainDef))
                {
                    nudGain.Minimum = gainMin;
                    nudGain.Maximum = gainMax;
                    if (nudGain.Value < nudGain.Minimum || nudGain.Value > nudGain.Maximum)
                        nudGain.Value = gainDef;
                }

                if (_cam.get_Brightness(out int brightness))
                    trackBrightness.Value = Math.Clamp(brightness, trackBrightness.Minimum, trackBrightness.Maximum);

                if (_cam.get_Contrast(out int contrast))
                    trackContrast.Value = Math.Clamp(contrast, trackContrast.Minimum, trackContrast.Maximum);

                if (_cam.get_Option(Toupcam.eOPTION.OPTION_SHARPENING, out int sharpenOpt))
                {
                    int strength = sharpenOpt & 0xffff;
                    trackSharpness.Value = Math.Clamp(strength, trackSharpness.Minimum, trackSharpness.Maximum);
                }

                if (_cam.get_ExpoTime(out uint expo))
                    nudExposure.Value = Math.Clamp((decimal)expo, nudExposure.Minimum, nudExposure.Maximum);

                if (_cam.get_ExpoAGain(out ushort gain))
                    nudGain.Value = Math.Clamp((decimal)gain, nudGain.Minimum, nudGain.Maximum);
            }
            finally
            {
                _isUpdatingSettingsUi = false;
                UpdateSettingValueLabels();
            }
        }

        private void ClearDefectResultsGrid()
        {
            foreach (DataGridViewRow row in dgvDefectResult.Rows)
            {
                if (row.Cells[colDefectCrop.Index].Value is Image img)
                {
                    img.Dispose();
                }
            }
            dgvDefectResult.Rows.Clear();
        }

        private void RenderDefectResults(IEnumerable<DefectResult> results)
        {
            ClearDefectResultsGrid();

            foreach (var item in results)
            {
                var positionText = $"X:{item.DefectRect.X}, Y:{item.DefectRect.Y}, W:{item.DefectRect.Width}, H:{item.DefectRect.Height}";
                Image? crop = item.CropImage == null ? null : (Image)item.CropImage.Clone();
                dgvDefectResult.Rows.Add(item.DefectName, positionText, crop);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

    }
}
