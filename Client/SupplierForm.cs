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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            var command = new MySqlCommand("SELECT * FROM Supplier", Program.Connection);
            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    var searchText = textBox1.Text.Trim();
            //    var command = new MySqlCommand(string.IsNullOrEmpty(searchText) ? "SELECT * FROM Supplier" : "SELECT * FROM Supplier WHERE SupplierID LIKE ?searchText", Program.Connection);
            //    command.Parameters.AddWithValue("searchText", "%" + searchText + "%");
            //    var adapter = new MySqlDataAdapter(command);
            //    var dataTable = new DataTable();
            //    try
            //    {
            //        adapter.Fill(dataTable);
            //        dataGridView1.DataSource = dataTable;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error searching suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var supplierDetailForm = new SupplierDetailForm();
            supplierDetailForm.ShowDialog();
        }
    }
}
