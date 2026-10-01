namespace Hwaseung;

public class LoginForm : Form
{
    private readonly TextBox _txtUsername;
    private readonly TextBox _txtPassword;
    private readonly Label _lblUsername;
    private readonly Label _lblPassword;
    private readonly Label _lblLanguage;
    private readonly Label _lblHint;
    private readonly ComboBox _cboLanguage;
    private readonly Button _btnLogin;
    private readonly Button _btnCancel;

    public LoginForm()
    {
        SessionContext.Language = "en";

        Text = "Login";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        MinimizeBox = false;
        Width = 380;
        Height = 270;

        _lblUsername = new Label
        {
            Text = "Username",
            Left = 25,
            Top = 25,
            Width = 80
        };

        _txtUsername = new TextBox
        {
            Left = 110,
            Top = 22,
            Width = 200
        };

        _lblPassword = new Label
        {
            Text = "Password",
            Left = 25,
            Top = 65,
            Width = 80
        };

        _txtPassword = new TextBox
        {
            Left = 110,
            Top = 62,
            Width = 200,
            UseSystemPasswordChar = true
        };

        _lblLanguage = new Label
        {
            Text = "Language",
            Left = 25,
            Top = 105,
            Width = 80
        };

        _cboLanguage = new ComboBox
        {
            Left = 110,
            Top = 102,
            Width = 200,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        _cboLanguage.Items.AddRange(new object[]
        {
            "English",
            "Tiếng Việt",
            "한국어",
            "中文"
        });
        _cboLanguage.SelectedIndex = 0;
        _cboLanguage.SelectedIndexChanged += CboLanguage_SelectedIndexChanged;

        _btnLogin = new Button
        {
            Text = "Login",
            Left = 110,
            Top = 145,
            Width = 95
        };
        _btnLogin.Click += BtnLogin_Click;

        _btnCancel = new Button
        {
            Text = "Exit",
            Left = 215,
            Top = 145,
            Width = 95
        };
        _btnCancel.Click += (_, _) =>
        {
            DialogResult = DialogResult.Cancel;
            Close();
        };

        _lblHint = new Label
        {
            Left = 25,
            Top = 185,
            Width = 330,
            Height = 35,
            Text = "Sample accounts: admin/admin123, user/user123"
        };

        Controls.Add(_lblUsername);
        Controls.Add(_txtUsername);
        Controls.Add(_lblPassword);
        Controls.Add(_txtPassword);
        Controls.Add(_lblLanguage);
        Controls.Add(_cboLanguage);
        Controls.Add(_btnLogin);
        Controls.Add(_btnCancel);
        Controls.Add(_lblHint);

        AcceptButton = _btnLogin;
        CancelButton = _btnCancel;

        ApplyLanguage();
    }

    private void CboLanguage_SelectedIndexChanged(object? sender, EventArgs e)
    {
        SessionContext.Language = _cboLanguage.SelectedIndex switch
        {
            1 => "vi",
            2 => "ko",
            3 => "zh",
            _ => "en"
        };

        ApplyLanguage();
    }

    private void ApplyLanguage()
    {
        Text = LocalizationService.T("Login_Title");
        _lblUsername.Text = LocalizationService.T("Login_Username");
        _lblPassword.Text = LocalizationService.T("Login_Password");
        _lblLanguage.Text = LocalizationService.T("Login_Language");
        _btnLogin.Text = LocalizationService.T("Login_Button");
        _btnCancel.Text = LocalizationService.T("Login_Exit");
        _lblHint.Text = LocalizationService.T("Login_SampleAccounts");
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        var username = _txtUsername.Text.Trim();
        var password = _txtPassword.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show(
                LocalizationService.T("Login_MissingInfo_Message"),
                LocalizationService.T("Login_MissingInfo_Title"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (!AuthService.TryAuthenticate(username, password, out var role))
        {
            MessageBox.Show(
                LocalizationService.T("Login_Failed_Message"),
                LocalizationService.T("Login_Failed_Title"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        SessionContext.Username = username;
        SessionContext.Role = role;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void InitializeComponent()
    {

    }
}
