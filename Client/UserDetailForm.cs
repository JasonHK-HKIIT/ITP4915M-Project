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
        private readonly string UserId;

        public UserDetailForm()
        {
            InitializeComponent();
        }

        public UserDetailForm(string userId) : this()
        {
            IsEditMode = true;
            UserId = userId;

            UserIdField.ReadOnly = true;
        }

        private void UserDetailForm_Load(object sender, EventArgs e)
        {
            var teamsCommand = new MySqlCommand("SELECT TeamID, TeamName FROM WorkerTeam", Program.Connection);
            var teamsAdapter = new MySqlDataAdapter(teamsCommand);
            var teamsTable = new DataTable();
            teamsAdapter.Fill(teamsTable);
            teamsTable.Rows.InsertAt(teamsTable.NewRow(), 0);
            TeamField.ValueMember = "TeamID";
            TeamField.DisplayMember = "TeamName";
            TeamField.DataSource = teamsTable;

            var managersCommand = new MySqlCommand("SELECT UserID, Name FROM User WHERE Role IN ('Admin', 'Manager')", Program.Connection);
            var managersAdapter = new MySqlDataAdapter(managersCommand);
            var managersTable = new DataTable();
            managersAdapter.Fill(managersTable);
            managersTable.Rows.InsertAt(managersTable.NewRow(), 0);
            ManagerField.ValueMember = "UserID";
            ManagerField.DisplayMember = "Name";
            ManagerField.DataSource = managersTable;

            if (IsEditMode)
            {
                var command = new MySqlCommand("SELECT UserID, Name, TeamID, PositionTitle, Role, ManagerID, IsActive FROM User WHERE UserID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", UserId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UserIdField.Text = (string)reader["UserID"];
                    NameField.Text = (string)reader["Name"];
                    TeamField.SelectedValue = reader["TeamID"];
                    PositionField.SelectedItem = (string)reader["PositionTitle"];
                    RoleField.SelectedItem = reader["Role"];
                    ManagerField.SelectedValue = reader["ManagerID"];
                    ActivatedField.Checked = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            else
            {
                RoleField.SelectedIndex = 0;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsEditMode)
                {
                    var command = new MySqlCommand("UPDATE User SET Name = ?name, TeamID = ?teamId, PositionTitle = ?position, Role = ?role, ManagerID = ?managerId, IsActive = ?isActive WHERE UserID = ?id", Program.Connection);
                    command.Parameters.AddWithValue("?id", UserIdField.Text);
                    command.Parameters.AddWithValue("?name", NameField.Text);
                    command.Parameters.AddWithValue("?teamId", TeamField.SelectedValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("?position", PositionField.SelectedItem);
                    command.Parameters.AddWithValue("?role", RoleField.SelectedItem);
                    command.Parameters.AddWithValue("?managerId", ManagerField.SelectedValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("?isActive", ActivatedField.Checked);
                    command.ExecuteNonQuery();

                    var password = PasswordField.Text;
                    if (!string.IsNullOrEmpty(password))
                    {
                        var passwordCommand = new MySqlCommand("UPDATE User SET PasswordHash = ?password WHERE UserID = ?id", Program.Connection);
                        passwordCommand.Parameters.AddWithValue("?id", UserIdField.Text);
                        passwordCommand.Parameters.AddWithValue("?password", Program.HashPassword(password));
                        passwordCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    var password = PasswordField.Text;
                    if (string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var lastIdCommand = new MySqlCommand("SELECT UserID FROM User ORDER BY UserID DESC LIMIT 1", Program.Connection);
                    var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "U000";
                    var nextId = int.Parse(lastIdString.Substring(1)) + 1;

                    var command = new MySqlCommand("INSERT INTO User (UserID, Name, PasswordHash, TeamID, PositionTitle, Role, ManagerID, IsActive) VALUES (?id, ?name, ?password, ?teamId, ?position, ?role, ?managerId, ?isActive)", Program.Connection);
                    command.Parameters.AddWithValue("?id", $"U{nextId.ToString().PadLeft(3, '0')}");
                    command.Parameters.AddWithValue("?name", NameField.Text);
                    command.Parameters.AddWithValue("?password", Program.HashPassword(password));
                    command.Parameters.AddWithValue("?teamId", TeamField.SelectedValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("?position", PositionField.SelectedItem);
                    command.Parameters.AddWithValue("?role", RoleField.SelectedItem);
                    command.Parameters.AddWithValue("?managerId", ManagerField.SelectedValue ?? DBNull.Value);
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
