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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var query = SearchField.Text.Trim();
            var command = new MySqlCommand(string.IsNullOrEmpty(query)
                ? "SELECT UserID, Username, Role, IsActive, CreatedAt FROM User"
                : "SELECT UserID, Username, Role, IsActive, CreatedAt FROM User WHERE Username LIKE ?username", Program.Connection);
            command.Parameters.AddWithValue("?username", $"%{query}%");
            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading admin data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SearchField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                LoadData();
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            using (var detail = new UserDetailForm())
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }

            var id = (int) dataGridView1.SelectedRows[0].Cells["UserID"].Value;
            using (var detail = new UserDetailForm(id))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }

}
