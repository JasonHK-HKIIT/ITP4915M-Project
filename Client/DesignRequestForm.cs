using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace Client
{
    public partial class DesignRequestForm : Form
    {
        public DesignRequestForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var query = SearchField.Text.Trim();

            string baseQuery = @"
                SELECT 
                    dr.DesignRequestID,
                    c.CustomerName,
                    dr.RequestDate,
                    dr.Specifications,
                    dr.Status,
                    dr.ConsultantFee,
                    dr.ApprovalDate,
                    u1.Name AS AssignedManagerName,
                    u2.Name AS ApprovedBy
                FROM ProductDesignRequest dr
                LEFT JOIN Customer c ON dr.CustomerID = c.CustomerID
                LEFT JOIN User u1 ON dr.UserID = u1.UserID
                LEFT JOIN User u2 ON dr.ApprovedBy = u2.UserID";

            string filteredQuery = baseQuery + " WHERE dr.DesignRequestID LIKE ?id";

            var command = new MySqlCommand(string.IsNullOrEmpty(query) ? baseQuery : filteredQuery, Program.Connection);

            if (!string.IsNullOrEmpty(query))
                command.Parameters.AddWithValue("?id", $"%{query}%");

            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();

            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading design requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesignRequestForm_Load(object sender, EventArgs e)
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var detail = new DesignRequestDetailForm())
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
                MessageBox.Show("Please select a design request to edit.");
                return;
            }

            var id = (string)dataGridView1.SelectedRows[0].Cells["DesignRequestID"].Value;
            using (var detail = new DesignRequestDetailForm(id))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle cell click events here
        }
    }
}
