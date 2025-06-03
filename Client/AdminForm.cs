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
    public partial class AdminForm : Form
    {
        public class UserRecord
        {
            public string Username { get; set; }
            public string Password { get; set; } // In real apps, never store plain passwords!
            public string Role { get; set; }
            public bool Active { get; set; }
        }

        private List<UserRecord> users = new List<UserRecord>();

        public AdminForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users.Select(u => new
            {
                u.Username,
                u.Role,
                u.Active
            }).ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new UserDetailForm())
            {
                detail.Text = "Add User";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    users.Add(new UserRecord
                    {
                        Username = detail.Username,
                        Password = detail.Password,
                        Role = detail.Role,
                        Active = detail.Active
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int idx = dataGridView1.SelectedRows[0].Index;
            var user = users[idx];
            using (var detail = new UserDetailForm())
            {
                detail.Text = "Edit User";
                detail.SetFields(user.Username, user.Password, user.Role, user.Active);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    user.Username = detail.Username;
                    user.Password = detail.Password;
                    user.Role = detail.Role;
                    user.Active = detail.Active;
                    BindDataGrid();
                }
            }
        }
    }

}
