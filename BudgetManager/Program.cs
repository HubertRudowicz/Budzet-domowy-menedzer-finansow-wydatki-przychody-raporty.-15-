using System.Globalization;

namespace projekttest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var culture = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // Pokaż okno logowania
            using (var loginForm = new Forms.LoginForm())
            {
                Application.Run(loginForm);
                
                // Jeśli zalogowano pomyślnie, uruchom główną aplikację
                if (loginForm.IsLoggedIn)
                {
                    Application.Run(new Form1());
                }
            }
        }
    }
}