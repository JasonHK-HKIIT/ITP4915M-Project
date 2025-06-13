using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class QuotationForm : Form
    {
        public QuotationForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string query = SearchField.Text.Trim();
            string sql = @"
        SELECT 
            QuotationID, 
            CustomerName, 
            QuotationDate, 
            ProductName, 
            Quantity, 
            TotalAmount, 
            Status, 
            ValidityPeriod, 
            DiscountAmount 
        FROM Quotation 
        LEFT JOIN Customer ON Quotation.CustomerID = Customer.CustomerID 
        LEFT JOIN Product ON Quotation.ProductID = Product.ProductID";

            if (!string.IsNullOrEmpty(query))
            {
                sql += " WHERE QuotationID LIKE @q OR CustomerName LIKE @q";
            }

            using var command = new MySqlCommand(sql, Program.Connection);
            if (!string.IsNullOrEmpty(query))
            {
                command.Parameters.AddWithValue("@q", $"%{query}%");
            }

            using var adapter = new MySqlDataAdapter(command);
            var dataTable = new System.Data.DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading quotations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void QuotationForm_Load(object sender, EventArgs e)
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

        private void NewButton_Click(object sender, EventArgs e)
        {
            using (var detail = new QuotationDetailForm())
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
                MessageBox.Show("Please select a quotation to edit.");
                return;
            }

            var id = (string)dataGridView1.SelectedRows[0].Cells["QuotationID"].Value;
            using (var detail = new QuotationDetailForm(id))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
