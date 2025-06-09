using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class ServiceCaseForm : Form
    {
        public ServiceCaseForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            button3.Click += ButtonDelete_Click;
            textBox1.KeyUp += textBox1_KeyUp;
            LoadData();
        }

        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            MySqlCommand command;

            string baseQuery = @"SELECT 
                csc.CaseID,
                c.CustomerName AS Customer,
                csc.CustomerOrderID AS `Order`,
                csc.CaseType,
                csc.Status,
                u.Name AS AssignedTo
                FROM CustomerServiceCase csc
                LEFT JOIN Customer c ON csc.CustomerID = c.CustomerID
                LEFT JOIN User u ON csc.AssignedStaffID = u.UserID";

            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(baseQuery, Program.Connection);
            }
            else
            {
                command = new MySqlCommand(baseQuery + " WHERE csc.CaseID LIKE @caseid", Program.Connection);
                command.Parameters.AddWithValue("@caseid", "%" + query + "%");
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
                MessageBox.Show("Error loading service cases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new ServiceCaseDetailForm())
            {
                detail.Text = "Add Service Case";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"INSERT INTO CustomerServiceCase
                          (CaseID, CustomerID, CustomerOrderID, CaseDate, Description, Status, Resolution, CaseType, AssignedStaffID)
                          VALUES
                          (@CaseID, @CustomerID, @CustomerOrderID, @CaseDate, @Description, @Status, @Resolution, @CaseType, @AssignedStaffID)",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@CaseID", detail.CaseID);
                        command.Parameters.AddWithValue("@CustomerID", detail.CustomerID);
                        command.Parameters.AddWithValue("@CustomerOrderID",
                            string.IsNullOrWhiteSpace(detail.CustomerOrderID) ? (object)DBNull.Value : detail.CustomerOrderID);
                        command.Parameters.AddWithValue("@CaseDate", detail.CaseDate);
                        command.Parameters.AddWithValue("@Description", detail.Description);
                        command.Parameters.AddWithValue("@Status", detail.Status);
                        command.Parameters.AddWithValue("@Resolution",
                            string.IsNullOrWhiteSpace(detail.Resolution) ? (object)DBNull.Value : detail.Resolution);
                        command.Parameters.AddWithValue("@CaseType", detail.CaseType);
                        command.Parameters.AddWithValue("@AssignedStaffID",
                            string.IsNullOrWhiteSpace(detail.AssignedStaffID) ? (object)DBNull.Value : detail.AssignedStaffID);

                        try { command.ExecuteNonQuery(); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding service case: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service case to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string caseID = dataGridView1.SelectedRows[0].Cells["CaseID"].Value.ToString();

            string customerOrderID = "";
            string customerID = "", description = "", status = "", resolution = "", caseType = "", assignedStaffID = "";
            DateTime caseDate = DateTime.Now;

            using (var fetch = new MySqlCommand("SELECT * FROM CustomerServiceCase WHERE CaseID=@id", Program.Connection))
            {
                fetch.Parameters.AddWithValue("@id", caseID);
                using (var reader = fetch.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerID = reader["CustomerID"].ToString();
                        customerOrderID = reader["CustomerOrderID"] == DBNull.Value ? "" : reader["CustomerOrderID"].ToString();
                        caseDate = reader["CaseDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["CaseDate"]);
                        description = reader["Description"].ToString();
                        status = reader["Status"].ToString();
                        resolution = reader["Resolution"] == DBNull.Value ? "" : reader["Resolution"].ToString();
                        caseType = reader["CaseType"].ToString();
                        assignedStaffID = reader["AssignedStaffID"] == DBNull.Value ? "" : reader["AssignedStaffID"].ToString();
                    }
                }
            }

            using (var detail = new ServiceCaseDetailForm())
            {
                detail.Text = "Edit Service Case";
                detail.SetFields(
                    caseID,
                    customerID,
                    customerOrderID,
                    caseDate,
                    description,
                    status,
                    resolution,
                    caseType,
                    assignedStaffID
                );

                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"UPDATE CustomerServiceCase SET
                          CustomerID=@CustomerID,
                          CustomerOrderID=@CustomerOrderID,
                          CaseDate=@CaseDate,
                          Description=@Description,
                          Status=@Status,
                          Resolution=@Resolution,
                          CaseType=@CaseType,
                          AssignedStaffID=@AssignedStaffID
                          WHERE CaseID=@CaseID", Program.Connection))
                    {
                        command.Parameters.AddWithValue("@CaseID", caseID);
                        command.Parameters.AddWithValue("@CustomerID", detail.CustomerID);
                        command.Parameters.AddWithValue("@CustomerOrderID",
                            string.IsNullOrWhiteSpace(detail.CustomerOrderID) ? (object)DBNull.Value : detail.CustomerOrderID);
                        command.Parameters.AddWithValue("@CaseDate", detail.CaseDate);
                        command.Parameters.AddWithValue("@Description", detail.Description);
                        command.Parameters.AddWithValue("@Status", detail.Status);
                        command.Parameters.AddWithValue("@Resolution",
                            string.IsNullOrWhiteSpace(detail.Resolution) ? (object)DBNull.Value : detail.Resolution);
                        command.Parameters.AddWithValue("@CaseType", detail.CaseType);
                        command.Parameters.AddWithValue("@AssignedStaffID",
                            string.IsNullOrWhiteSpace(detail.AssignedStaffID) ? (object)DBNull.Value : detail.AssignedStaffID);

                        try { command.ExecuteNonQuery(); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating service case: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service case to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string caseID = dataGridView1.SelectedRows[0].Cells["CaseID"].Value.ToString();
            var confirm = MessageBox.Show("Are you sure you want to delete this service case?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var command = new MySqlCommand("DELETE FROM CustomerServiceCase WHERE CaseID=@id", Program.Connection))
            {
                command.Parameters.AddWithValue("@id", caseID);

                try { command.ExecuteNonQuery(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting service case: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadData();
        }

        private void ServiceCaseForm_Load(object sender, EventArgs e)
        {
            // optional: add refresh or setup logic
        }
    }
}
