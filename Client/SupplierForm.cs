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
        public class Supplier
        {
            public string SupplierID { get; set; }
            public string Name { get; set; }
            public string Contact { get; set; }
        }
        private List<Supplier> suppliers = new List<Supplier>();

        public SupplierForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = suppliers.ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new SupplierDetailForm())
            {
                detail.Text = "Add Supplier";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    suppliers.Add(new Supplier
                    {
                        SupplierID = detail.SupplierID,
                        Name = detail.SupplierName,
                        Contact = detail.Contact
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int idx = dataGridView1.SelectedRows[0].Index;
            var supplier = suppliers[idx];
            using (var detail = new SupplierDetailForm())
            {
                detail.Text = "Edit Supplier";
                detail.SetFields(supplier.SupplierID, supplier.Name, supplier.Contact);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    supplier.SupplierID = detail.SupplierID;
                    supplier.Name = detail.SupplierName;
                    supplier.Contact = detail.Contact;
                    BindDataGrid();
                }
            }
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
