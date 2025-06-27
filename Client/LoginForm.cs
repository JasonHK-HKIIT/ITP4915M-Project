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

        private bool passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();

            // Set form icon and logo
            pictureBox1.Image = Properties.Resources.Logo_Sun;
            this.Icon = Properties.Resources.Icon_Sun;

            // Set eye icon initial state
            pictureBox2.Image = Properties.Resources.eye_closed;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Click += PictureBoxToggle_Click;

            buttonLogin.Click += buttonLogin_Click;

            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);

            inputPassword.UseSystemPasswordChar = true;
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

        private void PictureBoxToggle_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            inputPassword.UseSystemPasswordChar = !passwordVisible;
            pictureBox2.Image = passwordVisible ? Properties.Resources.eye_open : Properties.Resources.eye_closed;
        }

       
        private bool IsValidLogin(string username, string password, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "User ID and password cannot be empty.";
                return false;
            }

            var command = new MySqlCommand("SELECT PasswordHash FROM User WHERE UserID = @uid", Program.Connection);
            command.Parameters.AddWithValue("@uid", username);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                errorMessage = "Invalid User ID or password.";
                return false;
            }

            string hash = reader.GetString("PasswordHash");
            if (!Program.VerifyPassword(password, hash))
            {
                errorMessage = "Invalid User ID or password.";
                return false;
            }

            return true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Text.Trim();
            string password = inputPassword.Text;

            if (IsValidLogin(username, password, out string error))
            {
                var command = new MySqlCommand("SELECT UserID, TeamID, Role, PositionTitle FROM User WHERE UserID = @uid", Program.Connection);
                command.Parameters.AddWithValue("@uid", username);
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
            else
            {
                MessageBox.Show(error, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inputUsername.Clear();
                inputPassword.Clear();
                inputUsername.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e) { }
    }
}
