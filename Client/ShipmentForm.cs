using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class ShipmentForm : Form
    {
        public ShipmentForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;    // Add Shipment
            button2.Click += ButtonEdit_Click;   // Edit Shipment
            button3.Click += ButtonDelete_Click; // Delete Shipment
            textBox1.KeyUp += textBox1_KeyUp;    // Search
            LoadData();
        }

        // Load shipments (optionally filter by ShipmentID)
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            MySqlCommand command;
            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(
                    "SELECT ShipmentID, CustomerOrderID, Carrier, TrackingNumber, ShipmentDate, Status, IssueDate FROM Shipment",
                    Program.Connection);
            }
            else
            {
                command = new MySqlCommand(
                    "SELECT ShipmentID, CustomerOrderID, Carrier, TrackingNumber, ShipmentDate, Status, IssueDate FROM Shipment WHERE ShipmentID LIKE @q OR CustomerOrderID LIKE @q",
                    Program.Connection);
                command.Parameters.AddWithValue("@q", "%" + query + "%");
            }

            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        // Search by ShipmentID/CustomerOrderID
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.Handled = true;
            }
        }

        // Add new shipment
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new ShipmentDetailForm())
            {
                detail.Text = "Add Shipment";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"INSERT INTO Shipment
                        (ShipmentID, CustomerOrderID, Carrier, TrackingNumber, ShipmentDate, Status, IssueDate)
                        VALUES (@sid, @coid, @car, @track, @sdate, @status, @idate)",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@sid", detail.ShipmentID);
                        command.Parameters.AddWithValue("@coid", detail.CustomerOrderID);
                        command.Parameters.AddWithValue("@car", detail.Carrier);
                        command.Parameters.AddWithValue("@track", detail.TrackingNumber);
                        command.Parameters.AddWithValue("@sdate", detail.ShipmentDate);
                        command.Parameters.AddWithValue("@status", detail.Status);
                        command.Parameters.AddWithValue("@idate", detail.IssueDate);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding shipment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        // Edit shipment
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a shipment to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string origId = row.Cells["ShipmentID"].Value.ToString();
            string customerOrderID = row.Cells["CustomerOrderID"].Value.ToString();
            string carrier = row.Cells["Carrier"].Value.ToString();
            string trackingNumber = row.Cells["TrackingNumber"].Value.ToString();
            DateTime shipmentDate = Convert.ToDateTime(row.Cells["ShipmentDate"].Value);
            string status = row.Cells["Status"].Value.ToString();
            DateTime issueDate = Convert.ToDateTime(row.Cells["IssueDate"].Value);

            using (var detail = new ShipmentDetailForm())
            {
                detail.Text = "Edit Shipment";
                detail.SetFields(origId, customerOrderID, carrier, trackingNumber, shipmentDate, status, issueDate);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"UPDATE Shipment SET
                            ShipmentID=@sid, CustomerOrderID=@coid, Carrier=@car, TrackingNumber=@track,
                            ShipmentDate=@sdate, Status=@status, IssueDate=@idate
                          WHERE ShipmentID=@origId",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@sid", detail.ShipmentID);
                        command.Parameters.AddWithValue("@coid", detail.CustomerOrderID);
                        command.Parameters.AddWithValue("@car", detail.Carrier);
                        command.Parameters.AddWithValue("@track", detail.TrackingNumber);
                        command.Parameters.AddWithValue("@sdate", detail.ShipmentDate);
                        command.Parameters.AddWithValue("@status", detail.Status);
                        command.Parameters.AddWithValue("@idate", detail.IssueDate);
                        command.Parameters.AddWithValue("@origId", origId);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating shipment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        // Delete shipment
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a shipment to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string shipmentId = dataGridView1.SelectedRows[0].Cells["ShipmentID"].Value.ToString();
            var confirm = MessageBox.Show("Are you sure you want to delete this shipment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var command = new MySqlCommand(
                "DELETE FROM Shipment WHERE ShipmentID=@sid", Program.Connection))
            {
                command.Parameters.AddWithValue("@sid", shipmentId);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting shipment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadData();
        }
    }
}
