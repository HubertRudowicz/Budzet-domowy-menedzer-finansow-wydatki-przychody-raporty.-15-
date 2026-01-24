using System;
using System.Drawing;
using System.Windows.Forms;
using projekttest.Models;

namespace projekttest.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly IAuthService _authService;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnCancel;
        private Label lblError;

        public RegisterForm()
        {
            InitializeComponent();
            _authService = new AuthService(new BudgetDbContext());
        }

        private void InitializeComponent()
        {
            this.Text = "Rejestracja - Menadżer Finansów";
            this.Size = new Size(550, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var lblUsername = new Label { Text = "Login:", Location = new Point(100, 50), AutoSize = true };
            txtUsername = new TextBox { Location = new Point(100, 75), Width = 350 };

            var lblPassword = new Label { Text = "Hasło:", Location = new Point(100, 130), AutoSize = true };
            txtPassword = new TextBox { Location = new Point(100, 155), Width = 350, PasswordChar = '*' };

            var lblConfirmPassword = new Label { Text = "Powtórz hasło:", Location = new Point(100, 210), AutoSize = true };
            txtConfirmPassword = new TextBox { Location = new Point(100, 235), Width = 350, PasswordChar = '*' };

            btnRegister = new Button { Text = "Zarejestruj", Location = new Point(100, 310), Width = 350, Height = 45, BackColor = Color.LightGreen };
            btnRegister.Click += BtnRegister_Click;

            btnCancel = new Button { Text = "Anuluj", Location = new Point(100, 370), Width = 350, Height = 40 };
            btnCancel.Click += (s, e) => this.Close();

            lblError = new Label { Text = "", Location = new Point(100, 275), AutoSize = true, ForeColor = Color.Red };

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblConfirmPassword);
            this.Controls.Add(txtConfirmPassword);
            this.Controls.Add(btnRegister);
            this.Controls.Add(btnCancel);
            this.Controls.Add(lblError);
        }

        private void BtnRegister_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (password != confirm)
            {
                lblError.Text = "Hasła nie są identyczne.";
                return;
            }

            if (_authService.Register(username, password, out string error))
            {
                MessageBox.Show("Rejestracja pomyślna. Możesz się teraz zalogować.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lblError.Text = error;
            }
        }
    }
}
