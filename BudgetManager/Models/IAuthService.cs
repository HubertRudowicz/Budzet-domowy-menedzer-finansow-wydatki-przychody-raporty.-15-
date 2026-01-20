using System;

namespace projekttest.Models
{
    public interface IAuthService
    {
        bool Register(string username, string password, out string errorMessage);
        User? Login(string username, string password);
        User? CurrentUser { get; }
        void Logout();
    }
}
