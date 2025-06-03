using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            var command = new MySqlCommand(string.IsNullOrEmpty(query)
                ? "SELECT DesignRequestID, CustomerName, RequestDate, Specifications, Status, ConsultantFee, ApprovalDate, Worker.Name As AssignedManagerName FROM ProductDesignRequest LEFT JOIN Customer ON ProductDesignRequest.CustomerID = Customer.CustomerID LEFT JOIN Worker ON ProductDesignRequest.AssignedManagerID = Worker.WorkerID"
                : "SELECT DesignRequestID, CustomerName, RequestDate, Specifications, Status, ConsultantFee, ApprovalDate, Worker.Name As AssignedManagerName FROM ProductDesignRequest LEFT JOIN Customer ON ProductDesignRequest.CustomerID = Customer.CustomerID LEFT JOIN Worker ON ProductDesignRequest.AssignedManagerID = Worker.WorkerID WHERE DesignRequestID LIKE ?id", Program.Connection);
            command.Parameters.AddWithValue("?id", $"%{query}%");
            var adapter = new MySqlDataAdapter(command);
            var dataTable = new System.Data.DataTable();
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
    }
}
