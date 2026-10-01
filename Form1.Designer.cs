namespace Hwaseung
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            label1 = new Label();
            splitContainer2 = new SplitContainer();
            pictureBox1 = new PictureBox();
            panelMainControls = new Panel();
            flowMainControls = new FlowLayoutPanel();
            btnStart = new Button();
            btnStop = new Button();
            btnCapture = new Button();
            btnLogout = new Button();
            panel2 = new Panel();
            dgvDefectResult = new DataGridView();
            lblResultTableTitle = new Label();
            lblDefectHeader = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            panelSetting = new Panel();
            lblGainValue = new Label();
            lblExposureValue = new Label();
            lblSharpnessValue = new Label();
            lblContrastValue = new Label();
            lblBrightnessValue = new Label();
            btnReadSettings = new Button();
            btnApplySettings = new Button();
            chkAutoApply = new CheckBox();
            nudGain = new NumericUpDown();
            nudExposure = new NumericUpDown();
            trackSharpness = new TrackBar();
            trackContrast = new TrackBar();
            trackBrightness = new TrackBar();
            lblGain = new Label();
            lblExposure = new Label();
            lblSharpness = new Label();
            lblContrast = new Label();
            lblBrightness = new Label();
            colDefectType = new DataGridViewTextBoxColumn();
            colDefectPosition = new DataGridViewTextBoxColumn();
            colDefectCrop = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelMainControls.SuspendLayout();
            flowMainControls.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDefectResult).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panelSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudExposure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackSharpness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBrightness).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1462, 630);
            splitContainer1.SplitterDistance = 67;
            splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1462, 67);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(506, -1);
            label1.Name = "label1";
            label1.Size = new Size(735, 65);
            label1.TabIndex = 0;
            label1.Text = "FPCB INSPECTION PLATFORM";
            label1.Click += label1_Click_3;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(pictureBox1);
            splitContainer2.Panel1.Controls.Add(panelMainControls);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel2);
            splitContainer2.Size = new Size(1462, 559);
            splitContainer2.SplitterDistance = 983;
            splitContainer2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(983, 489);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelMainControls
            // 
            panelMainControls.BackColor = Color.Gainsboro;
            panelMainControls.Controls.Add(flowMainControls);
            panelMainControls.Dock = DockStyle.Bottom;
            panelMainControls.Location = new Point(0, 489);
            panelMainControls.Name = "panelMainControls";
            panelMainControls.Size = new Size(983, 70);
            panelMainControls.TabIndex = 1;
            // 
            // flowMainControls
            // 
            flowMainControls.Controls.Add(btnStart);
            flowMainControls.Controls.Add(btnStop);
            flowMainControls.Controls.Add(btnCapture);
            flowMainControls.Controls.Add(btnLogout);
            flowMainControls.Dock = DockStyle.Fill;
            flowMainControls.Location = new Point(0, 0);
            flowMainControls.Name = "flowMainControls";
            flowMainControls.Padding = new Padding(20, 10, 20, 10);
            flowMainControls.Size = new Size(983, 70);
            flowMainControls.TabIndex = 0;
            flowMainControls.WrapContents = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Gray;
            btnStart.ForeColor = Color.Black;
            btnStart.Location = new Point(23, 13);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(158, 52);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Gray;
            btnStop.ForeColor = Color.Black;
            btnStop.Location = new Point(187, 13);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(158, 52);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnCapture
            // 
            btnCapture.BackColor = Color.Gray;
            btnCapture.ForeColor = Color.Black;
            btnCapture.Location = new Point(351, 13);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(158, 52);
            btnCapture.TabIndex = 2;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = false;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Gray;
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(515, 13);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(158, 52);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(245, 248, 255);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(dgvDefectResult);
            panel2.Controls.Add(lblResultTableTitle);
            panel2.Controls.Add(lblDefectHeader);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(475, 559);
            panel2.TabIndex = 0;
            // 
            // dgvDefectResult
            // 
            dgvDefectResult.AllowUserToAddRows = false;
            dgvDefectResult.AllowUserToDeleteRows = false;
            dgvDefectResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDefectResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDefectResult.BackgroundColor = Color.White;
            dgvDefectResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDefectResult.Columns.AddRange(new DataGridViewColumn[] { colDefectType, colDefectPosition, colDefectCrop });
            dgvDefectResult.Location = new Point(14, 78);
            dgvDefectResult.MultiSelect = false;
            dgvDefectResult.Name = "dgvDefectResult";
            dgvDefectResult.ReadOnly = true;
            dgvDefectResult.RowHeadersVisible = false;
            dgvDefectResult.RowTemplate.Height = 84;
            dgvDefectResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDefectResult.Size = new Size(447, 468);
            dgvDefectResult.TabIndex = 8;
            // 
            // lblResultTableTitle
            // 
            lblResultTableTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResultTableTitle.AutoSize = true;
            lblResultTableTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultTableTitle.ForeColor = Color.FromArgb(30, 60, 114);
            lblResultTableTitle.Location = new Point(14, 54);
            lblResultTableTitle.Name = "lblResultTableTitle";
            lblResultTableTitle.Size = new Size(108, 20);
            lblResultTableTitle.TabIndex = 7;
            lblResultTableTitle.Text = "📋 Result List";
            // 
            // lblDefectHeader
            // 
            lblDefectHeader.BackColor = Color.FromArgb(30, 60, 114);
            lblDefectHeader.Dock = DockStyle.Top;
            lblDefectHeader.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefectHeader.ForeColor = Color.White;
            lblDefectHeader.Location = new Point(0, 0);
            lblDefectHeader.Name = "lblDefectHeader";
            lblDefectHeader.Padding = new Padding(8, 4, 8, 4);
            lblDefectHeader.Size = new Size(473, 44);
            lblDefectHeader.TabIndex = 0;
            lblDefectHeader.Text = "🎯 Defect Result";
            lblDefectHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1476, 674);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1468, 636);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panelSetting);
            tabPage2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1468, 636);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Setting";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelSetting
            // 
            panelSetting.Controls.Add(lblGainValue);
            panelSetting.Controls.Add(lblExposureValue);
            panelSetting.Controls.Add(lblSharpnessValue);
            panelSetting.Controls.Add(lblContrastValue);
            panelSetting.Controls.Add(lblBrightnessValue);
            panelSetting.Controls.Add(btnReadSettings);
            panelSetting.Controls.Add(btnApplySettings);
            panelSetting.Controls.Add(chkAutoApply);
            panelSetting.Controls.Add(nudGain);
            panelSetting.Controls.Add(nudExposure);
            panelSetting.Controls.Add(trackSharpness);
            panelSetting.Controls.Add(trackContrast);
            panelSetting.Controls.Add(trackBrightness);
            panelSetting.Controls.Add(lblGain);
            panelSetting.Controls.Add(lblExposure);
            panelSetting.Controls.Add(lblSharpness);
            panelSetting.Controls.Add(lblContrast);
            panelSetting.Controls.Add(lblBrightness);
            panelSetting.Dock = DockStyle.Fill;
            panelSetting.Location = new Point(3, 3);
            panelSetting.Name = "panelSetting";
            panelSetting.Size = new Size(1462, 630);
            panelSetting.TabIndex = 0;
            // 
            // lblGainValue
            // 
            lblGainValue.AutoSize = true;
            lblGainValue.Location = new Point(567, 295);
            lblGainValue.Name = "lblGainValue";
            lblGainValue.Size = new Size(61, 25);
            lblGainValue.TabIndex = 17;
            lblGainValue.Text = "100%";
            // 
            // lblExposureValue
            // 
            lblExposureValue.AutoSize = true;
            lblExposureValue.Location = new Point(567, 242);
            lblExposureValue.Name = "lblExposureValue";
            lblExposureValue.Size = new Size(92, 25);
            lblExposureValue.TabIndex = 16;
            lblExposureValue.Text = "20000 µs";
            // 
            // lblSharpnessValue
            // 
            lblSharpnessValue.AutoSize = true;
            lblSharpnessValue.Location = new Point(567, 187);
            lblSharpnessValue.Name = "lblSharpnessValue";
            lblSharpnessValue.Size = new Size(23, 25);
            lblSharpnessValue.TabIndex = 15;
            lblSharpnessValue.Text = "0";
            // 
            // lblContrastValue
            // 
            lblContrastValue.AutoSize = true;
            lblContrastValue.Location = new Point(567, 131);
            lblContrastValue.Name = "lblContrastValue";
            lblContrastValue.Size = new Size(23, 25);
            lblContrastValue.TabIndex = 14;
            lblContrastValue.Text = "0";
            // 
            // lblBrightnessValue
            // 
            lblBrightnessValue.AutoSize = true;
            lblBrightnessValue.Location = new Point(567, 74);
            lblBrightnessValue.Name = "lblBrightnessValue";
            lblBrightnessValue.Size = new Size(23, 25);
            lblBrightnessValue.TabIndex = 13;
            lblBrightnessValue.Text = "0";
            // 
            // btnReadSettings
            // 
            btnReadSettings.Location = new Point(413, 368);
            btnReadSettings.Name = "btnReadSettings";
            btnReadSettings.Size = new Size(138, 44);
            btnReadSettings.TabIndex = 12;
            btnReadSettings.Text = "Read Camera";
            btnReadSettings.UseVisualStyleBackColor = true;
            btnReadSettings.Click += btnReadSettings_Click;
            // 
            // btnApplySettings
            // 
            btnApplySettings.Location = new Point(252, 368);
            btnApplySettings.Name = "btnApplySettings";
            btnApplySettings.Size = new Size(138, 44);
            btnApplySettings.TabIndex = 11;
            btnApplySettings.Text = "Apply";
            btnApplySettings.UseVisualStyleBackColor = true;
            btnApplySettings.Click += btnApplySettings_Click;
            // 
            // chkAutoApply
            // 
            chkAutoApply.AutoSize = true;
            chkAutoApply.Checked = true;
            chkAutoApply.CheckState = CheckState.Checked;
            chkAutoApply.Location = new Point(252, 330);
            chkAutoApply.Name = "chkAutoApply";
            chkAutoApply.Size = new Size(132, 29);
            chkAutoApply.TabIndex = 10;
            chkAutoApply.Text = "Auto Apply";
            chkAutoApply.UseVisualStyleBackColor = true;
            // 
            // nudGain
            // 
            nudGain.Location = new Point(252, 291);
            nudGain.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            nudGain.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nudGain.Name = "nudGain";
            nudGain.Size = new Size(299, 33);
            nudGain.TabIndex = 9;
            nudGain.Value = new decimal(new int[] { 100, 0, 0, 0 });
            nudGain.ValueChanged += nudGain_ValueChanged;
            // 
            // nudExposure
            // 
            nudExposure.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudExposure.Location = new Point(252, 238);
            nudExposure.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudExposure.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nudExposure.Name = "nudExposure";
            nudExposure.Size = new Size(299, 33);
            nudExposure.TabIndex = 8;
            nudExposure.Value = new decimal(new int[] { 20000, 0, 0, 0 });
            nudExposure.ValueChanged += nudExposure_ValueChanged;
            // 
            // trackSharpness
            // 
            trackSharpness.Location = new Point(252, 181);
            trackSharpness.Maximum = 500;
            trackSharpness.Name = "trackSharpness";
            trackSharpness.Size = new Size(299, 45);
            trackSharpness.TabIndex = 7;
            trackSharpness.Scroll += trackSharpness_Scroll;
            // 
            // trackContrast
            // 
            trackContrast.Location = new Point(252, 125);
            trackContrast.Maximum = 255;
            trackContrast.Minimum = -255;
            trackContrast.Name = "trackContrast";
            trackContrast.Size = new Size(299, 45);
            trackContrast.TabIndex = 6;
            trackContrast.Scroll += trackContrast_Scroll;
            // 
            // trackBrightness
            // 
            trackBrightness.Location = new Point(252, 69);
            trackBrightness.Maximum = 255;
            trackBrightness.Minimum = -255;
            trackBrightness.Name = "trackBrightness";
            trackBrightness.Size = new Size(299, 45);
            trackBrightness.TabIndex = 5;
            trackBrightness.Scroll += trackBrightness_Scroll;
            // 
            // lblGain
            // 
            lblGain.AutoSize = true;
            lblGain.Location = new Point(63, 295);
            lblGain.Name = "lblGain";
            lblGain.Size = new Size(141, 25);
            lblGain.TabIndex = 4;
            lblGain.Text = "Exposure Gain";
            // 
            // lblExposure
            // 
            lblExposure.AutoSize = true;
            lblExposure.Location = new Point(63, 242);
            lblExposure.Name = "lblExposure";
            lblExposure.Size = new Size(143, 25);
            lblExposure.TabIndex = 3;
            lblExposure.Text = "Exposure Time";
            // 
            // lblSharpness
            // 
            lblSharpness.AutoSize = true;
            lblSharpness.Location = new Point(63, 187);
            lblSharpness.Name = "lblSharpness";
            lblSharpness.Size = new Size(102, 25);
            lblSharpness.TabIndex = 2;
            lblSharpness.Text = "Sharpness";
            // 
            // lblContrast
            // 
            lblContrast.AutoSize = true;
            lblContrast.Location = new Point(63, 131);
            lblContrast.Name = "lblContrast";
            lblContrast.Size = new Size(88, 25);
            lblContrast.TabIndex = 1;
            lblContrast.Text = "Contrast";
            // 
            // lblBrightness
            // 
            lblBrightness.AutoSize = true;
            lblBrightness.Location = new Point(63, 74);
            lblBrightness.Name = "lblBrightness";
            lblBrightness.Size = new Size(105, 25);
            lblBrightness.TabIndex = 0;
            lblBrightness.Text = "Brightness";
            // 
            // colDefectType
            // 
            colDefectType.HeaderText = "Type";
            colDefectType.Name = "colDefectType";
            colDefectType.ReadOnly = true;
            // 
            // colDefectPosition
            // 
            colDefectPosition.HeaderText = "Position";
            colDefectPosition.Name = "colDefectPosition";
            colDefectPosition.ReadOnly = true;
            // 
            // colDefectCrop
            // 
            colDefectCrop.HeaderText = "Crop image";
            colDefectCrop.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colDefectCrop.Name = "colDefectCrop";
            colDefectCrop.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1476, 674);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelMainControls.ResumeLayout(false);
            flowMainControls.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDefectResult).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panelSetting.ResumeLayout(false);
            panelSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGain).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudExposure).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackSharpness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBrightness).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private SplitContainer splitContainer2;
        private PictureBox pictureBox1;
        private Panel panelMainControls;
        private FlowLayoutPanel flowMainControls;
        private Panel panel1;
        private Panel panel2;
        private Button btnStart;
        private Button btnStop;
        private Button btnCapture;
        private Button btnLogout;
        private Label lblDefectHeader;
        private Label lblResultTableTitle;
        private DataGridView dgvDefectResult;
        private Panel panelSetting;
        private Label lblBrightness;
        private Label lblContrast;
        private Label lblSharpness;
        private Label lblExposure;
        private Label lblGain;
        private TrackBar trackBrightness;
        private TrackBar trackContrast;
        private TrackBar trackSharpness;
        private NumericUpDown nudExposure;
        private NumericUpDown nudGain;
        private CheckBox chkAutoApply;
        private Button btnApplySettings;
        private Button btnReadSettings;
        private Label lblBrightnessValue;
        private Label lblContrastValue;
        private Label lblSharpnessValue;
        private Label lblExposureValue;
        private Label lblGainValue;
        private DataGridViewTextBoxColumn colDefectType;
        private DataGridViewTextBoxColumn colDefectPosition;
        private DataGridViewImageColumn colDefectCrop;
    }
}
