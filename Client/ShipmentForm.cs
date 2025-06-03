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
        public ShipmentForm()
        {
            InitializeComponent();
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
