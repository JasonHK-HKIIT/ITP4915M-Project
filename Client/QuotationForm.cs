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

            // Restore default Windows form border
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;  // enable maximize if needed
            this.MinimizeBox = true;

            // Set form title (will appear in top-left)
            this.Text = "Quotation Form";
            this.Icon = Properties.Resources.Icon_Form;

            // Set UI font
            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);

            // Apply UI styles
            StyleButtons();
            StyleGrid();

        }

        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Font = font;
                if (ctrl.HasChildren)
                    ApplyFont(ctrl, font);
            }
        }

        private void StyleButtons()
        {
            ButtonStyle(NewButton, "Add Quotation", Color.MediumSeaGreen);
            ButtonStyle(EditButton, "Edit Selected", Color.CornflowerBlue);
        }

        private void ButtonStyle(Button button, string text, Color backColor)
        {
            button.Text = text;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private void StyleGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

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
