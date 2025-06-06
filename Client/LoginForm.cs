using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class LoginForm : Form
    {
        public bool LoggedIn { get; private set; } = false;

        public User User { get; private set; }

        public LoginForm()
        {
            this.InitializeComponent();
        }

        private bool IsValidLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("User ID and password cannot be empty.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var command = new MySqlCommand("SELECT PasswordHash FROM User WHERE UserID = ?uid", Program.Connection);
            command.Parameters.AddWithValue("uid", username);
            command.Parameters.AddWithValue("password", password);

            var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Invalid User ID or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
                return false;
            }
            var hash = reader.GetString("PasswordHash");
            reader.Close();
            return Program.VerifyPassword(password, hash);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (this.IsValidLogin(this.inputUsername.Text, this.inputPassword.Text))
            {
                var command = new MySqlCommand("SELECT UserID, TeamID, Role FROM User WHERE UserID = ?uid", Program.Connection);
                command.Parameters.AddWithValue("uid", this.inputUsername.Text);
                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("User not found in the database. This should not happen.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                    return;
                }

                this.LoggedIn = true;
                this.User = new User
                {
                    UserId = reader.GetString("UserID"),
                    TeamId = reader.GetString("TeamID"),
                    Role = reader.GetString("Role")
                };

                reader.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
