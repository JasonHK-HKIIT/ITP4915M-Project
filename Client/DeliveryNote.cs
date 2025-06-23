using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class DeliveryNoteForm : Form
    {
        private string shipmentId;

        public DeliveryNoteForm(string shipmentId)
        {
            InitializeComponent();
            this.shipmentId = shipmentId;
            LoadDeliveryNote();
        }

        private void LoadDeliveryNote()
        {
            string sql = @"
                SELECT 
                    s.ShipmentID, s.IssueDate, s.ShipmentDate, s.Carrier, s.TrackingNumber, s.Status,
                    c.CustomerName, c.CustomerPhoneNo, c.Address,
                    p.ProductID, p.ProductName, po.Quantity
                FROM Shipment s
                JOIN CustomerOrder co ON s.CustomerOrderID = co.CustomerOrderID
                JOIN Customer c ON co.CustomerID = c.CustomerID
                JOIN ProductionOrder po ON po.CustomerOrderID = co.CustomerOrderID
                JOIN Product p ON po.ProductID = p.ProductID
                WHERE s.ShipmentID = @sid";

            using var cmd = new MySqlCommand(sql, Program.Connection);
            cmd.Parameters.AddWithValue("@sid", shipmentId);

            using var adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                txtShipmentID.Text = row["ShipmentID"].ToString();      
                txtDeliveryID.Text = row["ShipmentID"].ToString();
                txtIssueDate.Text = Convert.ToDateTime(row["IssueDate"]).ToShortDateString();
                txtShipDate.Text = Convert.ToDateTime(row["ShipmentDate"]).ToShortDateString();
                txtCarrier.Text = row["Carrier"].ToString();
                txtTracking.Text = row["TrackingNumber"].ToString();
                txtStatus.Text = row["Status"].ToString();
                txtCustomerName.Text = row["CustomerName"].ToString();
                txtPhone.Text = row["CustomerPhoneNo"].ToString();
                txtAddress.Text = row["Address"].ToString();
            }

            dgvDeliveredItems.DataSource = table.DefaultView;

            
            string[] columnsToHide = {
                "ShipmentID", "IssueDate", "ShipmentDate", "Carrier", "TrackingNumber", "Status",
                "CustomerName", "CustomerPhoneNo", "Address"
            };

            foreach (string col in columnsToHide)
            {
                if (dgvDeliveredItems.Columns.Contains(col))
                    dgvDeliveredItems.Columns[col].Visible = false;
            }
        }
    }
}
