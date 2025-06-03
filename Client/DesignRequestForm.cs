using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class DesignRequestForm : Form
    {
        // Simple data model
        public class DesignRequest
        {
            public string Customer { get; set; }
            public string AssignedManager { get; set; }
            public string Specifications { get; set; }
        }

        private List<DesignRequest> requests = new List<DesignRequest>();

        public DesignRequestForm()
        {
            InitializeComponent();
            button3.Click += ButtonAdd_Click;   // "Add Request"
            // button2 (Approve) can be wired similarly if you need approval logic

            BindDataGrid();
        }

        private void LoadData()
        {
            var query = textBox1.Text.Trim();
            var command = new MySqlCommand(string.IsNullOrEmpty(query)
                ? "SELECT DesignRequestID, CustomerName, RequestDate, Specifications, Status, ConsultantFee, ApprovalDate, Worker.Name As AssignedManagerName FROM ProductDesignRequest LEFT JOIN Customer ON ProductDesignRequest.CustomerID = Customer.CustomerID LEFT JOIN Worker ON ProductDesignRequest.AssignedManagerID = Worker.WorkerID"
                : "SELECT DesignRequestID, CustomerName, RequestDate, Specifications, Status, ConsultantFee, ApprovalDate, Worker.Name As AssignedManagerName FROM ProductDesignRequest LEFT JOIN Customer ON ProductDesignRequest.CustomerID = Customer.CustomerID LEFT JOIN Worker ON ProductDesignRequest.AssignedManagerID = Worker.WorkerID WHERE DesignRequestID LIKE ?id", Program.Connection);
            command.Parameters.AddWithValue("?id", $"%{query}%");
            var adapter = new MySqlDataAdapter(command);
            var dataTable = new System.Data.DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = requests.ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new DesignRequestDetailForm())
            {
                detail.Text = "Add Design Request";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    requests.Add(new DesignRequest
                    {
                        Customer = detail.Customer,
                        AssignedManager = detail.AssignedManager,
                        Specifications = detail.Specifications
                    });
                    BindDataGrid();
                }
            }
        }

        private void DesignRequestForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }
    }
}
