using MySql.Data.MySqlClient;

namespace Client
{
    internal static class Program
    {
        private static readonly string DATABASE_IP = "127.0.0.1"; // "localhost"
        private static string CONNECTION_STRING = $"Server={DATABASE_IP};Database=SmileAndSunshineToyCo;User ID=root;Password=;Pooling=true;";

        public static MySqlConnection Connection { get; private set; } = new MySqlConnection(CONNECTION_STRING);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Connection.Open();
            Application.Run(new MF1());
            Connection.Close();
        }
    }
}