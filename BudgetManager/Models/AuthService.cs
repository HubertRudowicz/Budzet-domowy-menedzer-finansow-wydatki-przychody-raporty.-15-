using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace projekttest.Models
{
    public class AuthService : IAuthService
    {
        private readonly BudgetDbContext _context;
        public User? CurrentUser { get; private set; }

        public AuthService(BudgetDbContext context)
        {
            _context = context;
        }

        public bool Register(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Login i hasło nie mogą być puste.";
                return false;
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                errorMessage = "Użytkownik o takim loginie już istnieje.";
                return false;
            }

            var newUser = new User
            {
                Username = username,
                PasswordHash = HashPassword(password)
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return true;
        }

        public User? Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            string hash = HashPassword(password);
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);

            if (user != null)
            {
                CurrentUser = user;
            }

            return user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
