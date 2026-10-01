namespace Hwaseung;

internal static class LocalizationService
{
    private static readonly Dictionary<string, Dictionary<string, string>> _resources = new(StringComparer.OrdinalIgnoreCase)
    {
        ["en"] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Login_Title"] = "Login",
            ["Login_Username"] = "Username",
            ["Login_Password"] = "Password",
            ["Login_Button"] = "Login",
            ["Login_Exit"] = "Exit",
            ["Login_Language"] = "Language",
            ["Login_SampleAccounts"] = "Sample accounts: admin/admin123, user/user123",
            ["Login_MissingInfo_Message"] = "Please enter username and password.",
            ["Login_MissingInfo_Title"] = "Missing information",
            ["Login_Failed_Message"] = "Incorrect username or password.",
            ["Login_Failed_Title"] = "Login failed",

            ["App_Title"] = "FPCB Inspection",
            ["Main_Header"] = "FPCB INSPECTION PLATFORM",
            ["Main_Tab"] = "Main",
            ["Setting_Tab"] = "Settings",
            ["Result_List"] = "📋 Result List",
            ["Defect_Result"] = "🎯 Defect Result",
            ["Type"] = "Type",
            ["Position"] = "Position",
            ["Crop_Image"] = "Crop image",
            ["Start"] = "Start",
            ["Stop"] = "Stop",
            ["Capture"] = "Capture",
            ["Logout"] = "Logout",
            ["Read_Camera"] = "Read Camera",
            ["Apply"] = "Apply",
            ["Auto_Apply"] = "Auto Apply",
            ["Brightness"] = "Brightness",
            ["Contrast"] = "Contrast",
            ["Sharpness"] = "Sharpness",
            ["Exposure_Time"] = "Exposure Time",
            ["Exposure_Gain"] = "Exposure Gain",

            ["Notify_Title"] = "Notification",
            ["Success_Title"] = "Success",
            ["Error_Title"] = "Error",

            ["Camera_DllArch_Message"] = "Cannot load toupcam.dll due to architecture mismatch (x86/x64).\nPlease run app in x64 and use x64 Toupcam SDK.",
            ["Camera_DllLoad_Title"] = "Camera library load error",
            ["Camera_UvcOpened_Message"] = "Camera opened in UVC mode (DirectShow), not using Toupcam SDK.",
            ["Camera_NotFound_Title"] = "Camera not found",
            ["Camera_NotFound_Message"] = "Cannot find XCAM/ToupTek camera via USB.\n\nPlease check:\n1) Camera has power and status light is on.\n2) Correct camera driver is installed.\n3) Try another USB port/cable.\n4) Close other apps using camera.\n5) Check enterprise USB/camera access policy.\n\n{0}",
            ["Camera_CannotConnect1080p"] = "Cannot connect to XCam 1080p.",
            ["Capture_Saved"] = "Captured and saved inspection image: {0}",
            ["Stop_Camera_Success"] = "Camera stopped successfully.",
            ["Camera_NotConnected"] = "Camera is not connected.",
            ["Camera_Apply_Success"] = "Camera settings applied.",
            ["Camera_Apply_Failed"] = "Apply failed. HResult: {0} - {1}",
            ["Dll_Hint"] = "Cannot load toupcam.dll or its dependencies.\n\nCommon causes:\n1) DLL blocked by Application Control (error 4551 / 0x800711C7).\n2) Wrong DLL architecture (x86/x64).\n3) Missing VC++ runtime.\n\nQuick fix:\n- Open PowerShell (Run as Administrator) and run: Get-ChildItem -Recurse | Unblock-File\n- Ensure x64 configuration and x64 toupcam.dll.\n- If using AppLocker/WDAC, whitelist toupcam.dll per IT policy.\n\nError detail: {0}"
        },
        ["vi"] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Login_Title"] = "Đăng nhập",
            ["Login_Username"] = "Tên đăng nhập",
            ["Login_Password"] = "Mật khẩu",
            ["Login_Button"] = "Đăng nhập",
            ["Login_Exit"] = "Thoát",
            ["Login_Language"] = "Ngôn ngữ",
            ["Login_SampleAccounts"] = "Tài khoản mẫu: admin/admin123, user/user123",
            ["Login_MissingInfo_Message"] = "Vui lòng nhập tên đăng nhập và mật khẩu.",
            ["Login_MissingInfo_Title"] = "Thiếu thông tin",
            ["Login_Failed_Message"] = "Sai tên đăng nhập hoặc mật khẩu.",
            ["Login_Failed_Title"] = "Đăng nhập thất bại",

            ["App_Title"] = "Kiểm tra FPCB",
            ["Main_Header"] = "NỀN TẢNG KIỂM TRA FPCB",
            ["Main_Tab"] = "Chính",
            ["Setting_Tab"] = "Cài đặt",
            ["Result_List"] = "📋 Danh sách kết quả",
            ["Defect_Result"] = "🎯 Kết quả lỗi",
            ["Type"] = "Loại",
            ["Position"] = "Vị trí",
            ["Crop_Image"] = "Ảnh cắt",
            ["Start"] = "Bắt đầu",
            ["Stop"] = "Dừng",
            ["Capture"] = "Chụp",
            ["Logout"] = "Đăng xuất",
            ["Read_Camera"] = "Đọc camera",
            ["Apply"] = "Áp dụng",
            ["Auto_Apply"] = "Tự động áp dụng",
            ["Brightness"] = "Độ sáng",
            ["Contrast"] = "Độ tương phản",
            ["Sharpness"] = "Độ nét",
            ["Exposure_Time"] = "Thời gian phơi sáng",
            ["Exposure_Gain"] = "Gain phơi sáng",

            ["Notify_Title"] = "Thông báo",
            ["Success_Title"] = "Thành công",
            ["Error_Title"] = "Lỗi",

            ["Camera_DllArch_Message"] = "Không thể nạp toupcam.dll do sai kiến trúc (x86/x64).\nHãy chạy ứng dụng ở x64 và dùng đúng bản SDK x64.",
            ["Camera_DllLoad_Title"] = "Lỗi nạp thư viện camera",
            ["Camera_UvcOpened_Message"] = "Đã mở camera theo chế độ UVC (DirectShow), không dùng SDK Toupcam.",
            ["Camera_NotFound_Title"] = "Không tìm thấy camera",
            ["Camera_NotFound_Message"] = "Không tìm thấy Camera XCAM/ToupTek qua cổng USB.\n\nVui lòng kiểm tra:\n1) Camera đã được cấp nguồn và đèn trạng thái hoạt động.\n2) Đã cài đúng driver của hãng camera.\n3) Thử đổi cổng USB/cáp USB khác.\n4) Đóng các ứng dụng khác đang chiếm camera.\n5) Nếu đang dùng chính sách bảo mật doanh nghiệp, kiểm tra quyền truy cập USB/camera.\n\n{0}",
            ["Camera_CannotConnect1080p"] = "Không thể kết nối XCam 1080p!",
            ["Capture_Saved"] = "Đã chụp và lưu ảnh kiểm tra: {0}",
            ["Stop_Camera_Success"] = "Dừng camera thành công.",
            ["Camera_NotConnected"] = "Camera chưa kết nối.",
            ["Camera_Apply_Success"] = "Đã áp dụng thông số camera.",
            ["Camera_Apply_Failed"] = "Áp dụng thất bại. HResult: {0} - {1}",
            ["Dll_Hint"] = "Không thể nạp toupcam.dll hoặc dependency của nó.\n\nNguyên nhân phổ biến:\n1) DLL bị Application Control chặn (mã lỗi 4551 / 0x800711C7).\n2) Sai kiến trúc DLL (x86/x64).\n3) Thiếu VC++ runtime phụ thuộc.\n\nCách xử lý nhanh:\n- Mở PowerShell (Run as Administrator) và chạy: Get-ChildItem -Recurse | Unblock-File\n- Đảm bảo chạy cấu hình x64 và dùng toupcam.dll bản x64.\n- Nếu máy có AppLocker/WDAC, cần whitelist toupcam.dll theo chính sách IT.\n\nChi tiết lỗi: {0}"
        },
        ["ko"] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Login_Title"] = "로그인",
            ["Login_Username"] = "사용자 이름",
            ["Login_Password"] = "비밀번호",
            ["Login_Button"] = "로그인",
            ["Login_Exit"] = "종료",
            ["Login_Language"] = "언어",
            ["Login_SampleAccounts"] = "샘플 계정: admin/admin123, user/user123",
            ["Login_MissingInfo_Message"] = "사용자 이름과 비밀번호를 입력하세요.",
            ["Login_MissingInfo_Title"] = "정보 누락",
            ["Login_Failed_Message"] = "사용자 이름 또는 비밀번호가 올바르지 않습니다.",
            ["Login_Failed_Title"] = "로그인 실패",

            ["App_Title"] = "FPCB 검사",
            ["Main_Header"] = "FPCB 검사 플랫폼",
            ["Main_Tab"] = "메인",
            ["Setting_Tab"] = "설정",
            ["Result_List"] = "📋 결과 목록",
            ["Defect_Result"] = "🎯 결함 결과",
            ["Type"] = "유형",
            ["Position"] = "위치",
            ["Crop_Image"] = "크롭 이미지",
            ["Start"] = "시작",
            ["Stop"] = "중지",
            ["Capture"] = "캡처",
            ["Logout"] = "로그아웃",
            ["Read_Camera"] = "카메라 읽기",
            ["Apply"] = "적용",
            ["Auto_Apply"] = "자동 적용",
            ["Brightness"] = "밝기",
            ["Contrast"] = "대비",
            ["Sharpness"] = "선명도",
            ["Exposure_Time"] = "노출 시간",
            ["Exposure_Gain"] = "노출 게인",

            ["Notify_Title"] = "알림",
            ["Success_Title"] = "성공",
            ["Error_Title"] = "오류",

            ["Camera_DllArch_Message"] = "아키텍처 불일치(x86/x64)로 toupcam.dll을 로드할 수 없습니다.\n앱을 x64로 실행하고 x64 SDK를 사용하세요.",
            ["Camera_DllLoad_Title"] = "카메라 라이브러리 로드 오류",
            ["Camera_UvcOpened_Message"] = "Toupcam SDK 없이 UVC 모드(DirectShow)로 카메라를 열었습니다.",
            ["Camera_NotFound_Title"] = "카메라를 찾을 수 없음",
            ["Camera_NotFound_Message"] = "USB에서 XCAM/ToupTek 카메라를 찾을 수 없습니다.\n\n확인 사항:\n1) 카메라 전원 및 상태 LED\n2) 올바른 드라이버 설치\n3) 다른 USB 포트/케이블 사용\n4) 카메라 사용 중인 다른 앱 종료\n5) 회사 보안 정책의 USB/카메라 권한 확인\n\n{0}",
            ["Camera_CannotConnect1080p"] = "XCam 1080p에 연결할 수 없습니다.",
            ["Capture_Saved"] = "검사 이미지를 저장했습니다: {0}",
            ["Stop_Camera_Success"] = "카메라가 정상적으로 중지되었습니다.",
            ["Camera_NotConnected"] = "카메라가 연결되어 있지 않습니다.",
            ["Camera_Apply_Success"] = "카메라 설정이 적용되었습니다.",
            ["Camera_Apply_Failed"] = "적용 실패. HResult: {0} - {1}",
            ["Dll_Hint"] = "toupcam.dll 또는 종속성을 로드할 수 없습니다.\n\n일반적인 원인:\n1) Application Control에 의해 DLL 차단(오류 4551 / 0x800711C7)\n2) DLL 아키텍처 불일치(x86/x64)\n3) VC++ 런타임 누락\n\n빠른 조치:\n- PowerShell(관리자) 실행 후: Get-ChildItem -Recurse | Unblock-File\n- x64 구성 및 x64 toupcam.dll 사용 확인\n- AppLocker/WDAC 환경이면 IT 정책에 따라 toupcam.dll 허용\n\n오류 상세: {0}"
        },
        ["zh"] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Login_Title"] = "登录",
            ["Login_Username"] = "用户名",
            ["Login_Password"] = "密码",
            ["Login_Button"] = "登录",
            ["Login_Exit"] = "退出",
            ["Login_Language"] = "语言",
            ["Login_SampleAccounts"] = "示例账号: admin/admin123, user/user123",
            ["Login_MissingInfo_Message"] = "请输入用户名和密码。",
            ["Login_MissingInfo_Title"] = "信息缺失",
            ["Login_Failed_Message"] = "用户名或密码错误。",
            ["Login_Failed_Title"] = "登录失败",

            ["App_Title"] = "FPCB 检测",
            ["Main_Header"] = "FPCB 检测平台",
            ["Main_Tab"] = "主界面",
            ["Setting_Tab"] = "设置",
            ["Result_List"] = "📋 结果列表",
            ["Defect_Result"] = "🎯 缺陷结果",
            ["Type"] = "类型",
            ["Position"] = "位置",
            ["Crop_Image"] = "裁剪图像",
            ["Start"] = "开始",
            ["Stop"] = "停止",
            ["Capture"] = "拍摄",
            ["Logout"] = "退出登录",
            ["Read_Camera"] = "读取相机",
            ["Apply"] = "应用",
            ["Auto_Apply"] = "自动应用",
            ["Brightness"] = "亮度",
            ["Contrast"] = "对比度",
            ["Sharpness"] = "锐度",
            ["Exposure_Time"] = "曝光时间",
            ["Exposure_Gain"] = "曝光增益",

            ["Notify_Title"] = "提示",
            ["Success_Title"] = "成功",
            ["Error_Title"] = "错误",

            ["Camera_DllArch_Message"] = "由于架构不匹配(x86/x64)，无法加载 toupcam.dll。\n请以 x64 运行并使用 x64 SDK。",
            ["Camera_DllLoad_Title"] = "相机库加载错误",
            ["Camera_UvcOpened_Message"] = "已使用 UVC 模式(DirectShow)打开相机，未使用 Toupcam SDK。",
            ["Camera_NotFound_Title"] = "未找到相机",
            ["Camera_NotFound_Message"] = "未通过 USB 找到 XCAM/ToupTek 相机。\n\n请检查:\n1) 相机已供电且指示灯正常\n2) 已安装正确驱动\n3) 尝试更换 USB 端口/线缆\n4) 关闭占用相机的其他应用\n5) 检查企业安全策略中的 USB/相机权限\n\n{0}",
            ["Camera_CannotConnect1080p"] = "无法连接到 XCam 1080p。",
            ["Capture_Saved"] = "已拍摄并保存检测图像: {0}",
            ["Stop_Camera_Success"] = "相机已成功停止。",
            ["Camera_NotConnected"] = "相机未连接。",
            ["Camera_Apply_Success"] = "相机参数已应用。",
            ["Camera_Apply_Failed"] = "应用失败。HResult: {0} - {1}",
            ["Dll_Hint"] = "无法加载 toupcam.dll 或其依赖项。\n\n常见原因:\n1) DLL 被应用程序控制阻止(错误 4551 / 0x800711C7)\n2) DLL 架构不匹配(x86/x64)\n3) 缺少 VC++ 运行库\n\n快速处理:\n- 以管理员身份打开 PowerShell 并执行: Get-ChildItem -Recurse | Unblock-File\n- 确保使用 x64 配置和 x64 toupcam.dll\n- 若使用 AppLocker/WDAC，请按 IT 策略放行 toupcam.dll\n\n错误详情: {0}"
        }
    };

    public static string T(string key, string? language = null)
    {
        var lang = NormalizeLanguage(language ?? SessionContext.Language);

        if (_resources.TryGetValue(lang, out var map) && map.TryGetValue(key, out var text))
        {
            return text;
        }

        if (_resources["en"].TryGetValue(key, out var fallback))
        {
            return fallback;
        }

        return key;
    }

    public static string NormalizeLanguage(string? language)
    {
        return language?.ToLowerInvariant() switch
        {
            "vi" => "vi",
            "ko" => "ko",
            "zh" => "zh",
            _ => "en"
        };
    }
}
