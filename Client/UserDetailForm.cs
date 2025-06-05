using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class UserDetailForm : Form
    {
        private readonly bool IsEditMode = false;
        private readonly int UserId;

        public UserDetailForm()
        {
            InitializeComponent();
        }

        public UserDetailForm(int userId) : this()
        {
            IsEditMode = true;
            UserId = userId;
        }

        private void UserDetailForm_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                var command = new MySqlCommand("SELECT Username, Role, IsActive FROM SystemUser WHERE UserID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", UserId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UsernameField.Text = (string)reader["Username"];
                    RoleField.SelectedItem = reader["Role"];
                    ActivatedField.Checked = (bool)reader["IsActive"];
                }
                reader.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsEditMode)
                {
                    var command = new MySqlCommand("UPDATE SystemUser SET Username = ?username, Role = ?role, IsActive = ?isActive WHERE UserID = ?id", Program.Connection);
                    command.Parameters.AddWithValue("?id", UserId);
                    command.Parameters.AddWithValue("?username", UsernameField.Text);
                    command.Parameters.AddWithValue("?role", RoleField.SelectedItem.ToString());
                    command.Parameters.AddWithValue("?isActive", ActivatedField.Checked);
                    command.ExecuteNonQuery();
                }
                else
                {
                    var command = new MySqlCommand("INSERT INTO SystemUser (Username, PasswordHash, Role, IsActive) VALUES (?username, ?password, ?role, ?isActive)", Program.Connection);
                    command.Parameters.AddWithValue("?username", UsernameField.Text);
                    command.Parameters.AddWithValue("?password", "defaultPasswordHash"); // Replace with actual password hash logic
                    command.Parameters.AddWithValue("?role", RoleField.SelectedItem.ToString());
                    command.Parameters.AddWithValue("?isActive", ActivatedField.Checked);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error saving user: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
