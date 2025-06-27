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

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;  // enable maximize if needed
            this.MinimizeBox = true;

            // Set form title (will appear in top-left)
            this.Text = "Admin Form";
            this.Icon = Properties.Resources.Icon_Form;

            // Set UI font
            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);

            // Apply UI styles
            StyleButtons();
            StyleGrid();

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

        private void StyleButtons()
        {
            ButtonStyle(NewButton, "Add User", Color.MediumSeaGreen);
            ButtonStyle(EditButton, "Edit Selected", Color.CornflowerBlue);
            ButtonStyle(button3, "Delete Selected", Color.IndianRed);
        }

        private void ButtonStyle(Button button, string text, Color backColor)
        {
            button.Text = text;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private void StyleGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        }

        private void LoadData()
        {
            var query = SearchField.Text.Trim();
            MySqlCommand command;

            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(
                    @"SELECT User.UserID, User.Name, TeamName, User.PositionTitle, User.Role, 
                     Manager.Name AS ManagerName, User.IsActive, User.CreatedAt 
              FROM User 
              LEFT JOIN WorkerTeam ON User.TeamID = WorkerTeam.TeamID 
              LEFT JOIN User AS Manager ON User.ManagerID = Manager.UserID",
                    Program.Connection
                );
            }
            else
            {
                command = new MySqlCommand(
                    @"SELECT User.UserID, User.Name, TeamName, User.PositionTitle, User.Role, 
                     Manager.Name AS ManagerName, User.IsActive, User.CreatedAt 
              FROM User 
              LEFT JOIN WorkerTeam ON User.TeamID = WorkerTeam.TeamID 
              LEFT JOIN User AS Manager ON User.ManagerID = Manager.UserID 
              WHERE User.UserID LIKE @q 
                 OR User.Name LIKE @q 
                 OR TeamName LIKE @q 
                 OR User.Role LIKE @q",
                    Program.Connection
                );
                command.Parameters.AddWithValue("@q", $"%{query}%");
            }

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

            var id = (string) dataGridView1.SelectedRows[0].Cells["UserID"].Value;
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