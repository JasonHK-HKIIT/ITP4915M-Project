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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            button2.Click += ButtonEdit_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var productDetailForm = new ProductDetailForm();
            productDetailForm.ShowDialog();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;
            var row = drv.Row;

            using (var productDetailForm = new ProductDetailForm())
            {
                productDetailForm.SetFields(
                    row["DesignRequestID"].ToString(),
                    row["ProductName"].ToString(),
                    row["ProductType"].ToString(),
                    row["UnitPrice"].ToString(),
                    row["Specifications"].ToString()
                );
                if (productDetailForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Product updated successfully (implement DB update here).", "Success");
                }
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            var command = new MySqlCommand("SELECT * FROM Product", Program.Connection);
            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchText = textBox1.Text.Trim();
                var command = new MySqlCommand(string.IsNullOrEmpty(searchText) ? "SELECT * FROM Product" : "SELECT * FROM Product WHERE ProductID LIKE ?searchText", Program.Connection);
                command.Parameters.AddWithValue("searchText", "%" + searchText + "%");
                var adapter = new MySqlDataAdapter(command);
                var dataTable = new DataTable();
                try
                {
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
