using MySql.Data.MySqlClient;
using System.Data;

namespace Client
{
    internal static class Program
    {
        private static readonly string DATABASE_IP = "127.0.0.1"; // "localhost"
        private static string CONNECTION_STRING = $"Server={Properties.Settings.Default.DatabaseHostname};Database=SmileAndSunshineToyCo;User ID=root;Password=;Pooling=true;";

        public static MySqlConnection Connection { get; private set; } = new MySqlConnection(CONNECTION_STRING);

        public static User User { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            while (Connection.State != ConnectionState.Open)
            {
                try
                {
                    Connection.Open();
                }
                catch (MySqlException ex)
                {
                    var result = MessageBox.Show($"Error connecting to the database: {ex.Message}", "Database Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result != DialogResult.Retry)
                    {
                        Application.Exit();
                        return;
                    }
                }
            }

            Application.Run(new MF1());
            Connection.Close();
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}