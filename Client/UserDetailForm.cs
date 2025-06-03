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
