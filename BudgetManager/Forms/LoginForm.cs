using System;
using System.Drawing;
using System.Windows.Forms;
using projekttest.Models;

namespace projekttest.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;
        public bool IsLoggedIn { get; private set; } = false;

        // Custom controls added programmatically
        private Button btnGoToRegister;
        private Label lblError;

        public LoginForm()
        {
            InitializeComponent(); // Calls Designer method
            
            // Initialize DbContext and AuthService
            _authService = new AuthService(new BudgetDbContext());
            
            // Ensure DB exists
            using (var db = new BudgetDbContext())
            {
                db.Database.EnsureCreated();
            }

            SetupCustomControls();
        }

        private void SetupCustomControls()
        {
            // Add Register button
            btnGoToRegister = new Button 
            { 
                Text = "Zarejestruj się", 
                Location = new Point(190, 240), // Center X: (500-250)/2 = 125. Y=270 (10px below Login/Cancel)
                Width = 250, 
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray
            };
            btnGoToRegister.Click += BtnGoToRegister_Click;
            this.Controls.Add(btnGoToRegister);

            // Add Error Label
            lblError = new Label 
            { 
                Text = "", 
                Location = new Point(150, 190), // Between Password and Buttons (Pass Y=147, But Y=220)
                AutoSize = true, 
                ForeColor = Color.Red 
            };
            this.Controls.Add(lblError);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _authService.Login(txtLogin.Text, txtPassword.Text);
            if (user != null)
            {
                IsLoggedIn = true;
                GlobalData.CurrentUser = user; 
                this.Close();
            }
            else
            {
                lblError.Text = "Nieprawidłowy login lub hasło.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Designer linked this event, might as well use it to submit on Enter
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void BtnGoToRegister_Click(object? sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }
    }
}
