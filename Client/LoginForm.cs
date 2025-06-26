using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        public bool LoggedIn { get; private set; } = false;
        public User User { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            // Set PictureBox image and window icon
            pictureBox1.Image = Properties.Resources.Logo_Sun;
            this.Icon = Properties.Resources.Icon_Sun;

            // Apply UI font
            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);
        }

        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Font = font;
                if (ctrl.HasChildren)
                    ApplyFont(ctrl, font);
            }
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
            command.Parameters.AddWithValue("password", password);  // NOTE: You probably don't need this unless the query uses it

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
                var command = new MySqlCommand("SELECT UserID, TeamID, Role, PositionTitle FROM User WHERE UserID = ?uid", Program.Connection);
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
                    Role = reader.GetString("Role"),
                    PositionTitle = reader.GetString("PositionTitle")
                };

                reader.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
