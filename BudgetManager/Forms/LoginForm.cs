using System;
using System.Windows.Forms;

namespace projekttest.Forms
{
    public partial class LoginForm : Form
    {
        public bool IsLoggedIn { get; private set; } = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AttemptLogin();
            }
        }

        private void AttemptLogin()
        {
            string username = txtLogin.Text;
            string password = txtPassword.Text;

            // Proste logowanie "na sztywno" - admin/admin
            if (username == "admin" && password == "admin")
            {
                IsLoggedIn = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło.\n(Spróbuj: admin / admin)", "Błąd Logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
