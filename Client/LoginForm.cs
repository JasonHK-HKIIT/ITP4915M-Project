using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class LoginForm : Form
    {
        public bool LoggedIn { get; private set; } = false;

        public LoginForm()
        {
            this.InitializeComponent();
        }

        private bool IsValidLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var command = new MySqlCommand("SELECT * FROM SystemUser WHERE Username = ?username AND PasswordHash = ?password", Program.Connection);
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);

            var reader = command.ExecuteReader();
            var isValid = reader.HasRows;
            if (!isValid)
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            reader.Close();
            return isValid;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (this.IsValidLogin(this.inputUsername.Text, this.inputPassword.Text))
            {
                this.LoggedIn = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                
            }
        }
    }
}
