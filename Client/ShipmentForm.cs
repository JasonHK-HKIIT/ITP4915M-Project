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
    public partial class ShipmentForm : Form
    {
        // Example shipment data class
        public class Shipment
        {
            public string ShipmentID { get; set; }
            public string CustomerOrder { get; set; }
            public string Carrier { get; set; }
            public string TrackingNumber { get; set; }
            public DateTime ShipmentDate { get; set; }
            public string Status { get; set; }
        }

        private List<Shipment> shipments = new List<Shipment>();

        public ShipmentForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            // button3 for delete

            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = shipments
                .Select(s => new
                {
                    s.ShipmentID,
                    s.CustomerOrder,
                    s.Carrier,
                    s.TrackingNumber,
                    ShipmentDate = s.ShipmentDate.ToShortDateString(),
                    s.Status
                }).ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new ShipmentDetailForm())
            {
                detail.Text = "Add Shipment";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    shipments.Add(new Shipment
                    {
                        ShipmentID = detail.ShipmentID,
                        CustomerOrder = detail.CustomerOrder,
                        Carrier = detail.Carrier,
                        TrackingNumber = detail.TrackingNumber,
                        ShipmentDate = detail.ShipmentDate,
                        Status = detail.Status
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int idx = dataGridView1.SelectedRows[0].Index;
            var shipment = shipments[idx];
            using (var detail = new ShipmentDetailForm())
            {
                detail.Text = "Edit Shipment";
                detail.SetFields(
                    shipment.ShipmentID,
                    shipment.CustomerOrder,
                    shipment.Carrier,
                    shipment.TrackingNumber,
                    shipment.ShipmentDate,
                    shipment.Status);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    shipment.ShipmentID = detail.ShipmentID;
                    shipment.CustomerOrder = detail.CustomerOrder;
                    shipment.Carrier = detail.Carrier;
                    shipment.TrackingNumber = detail.TrackingNumber;
                    shipment.ShipmentDate = detail.ShipmentDate;
                    shipment.Status = detail.Status;
                    BindDataGrid();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var shipmentDetailForm = new ShipmentDetailForm();
            shipmentDetailForm.ShowDialog();
        }

        private void ShipmentForm_Load(object sender, EventArgs e)
        {
            var command = new MySqlCommand("SELECT * FROM Shipment", Program.Connection);
            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shipments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchText = textBox1.Text.Trim();
                var command = new MySqlCommand(string.IsNullOrEmpty(searchText) ? "SELECT * FROM Shipment" : "SELECT * FROM Shipment WHERE ShipmentID LIKE ?searchText", Program.Connection);
                command.Parameters.AddWithValue("searchText", "%" + searchText + "%");
                var adapter = new MySqlDataAdapter(command);
                var dataTable = new DataTable();
                try
                {
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching shipments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
