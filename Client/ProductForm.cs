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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;  // enable maximize if needed
            this.MinimizeBox = true;

            // Set form title (will appear in top-left)
            this.Text = "Product Form";
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
            ButtonStyle(AddButton, "Add Product", Color.MediumSeaGreen);
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
            var query = SearchField.Text.Trim();
            var command = new MySqlCommand(string.IsNullOrEmpty(query)
                ? "SELECT * FROM Product"
                : "SELECT * FROM Product WHERE ProductID LIKE ?id", Program.Connection);
            command.Parameters.AddWithValue("?id", $"%{query}%");
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

        private void ProductForm_Load(object sender, EventArgs e)
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var detail = new ProductDetailForm())
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
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            var id = (string)dataGridView1.SelectedRows[0].Cells["ProductID"].Value;
            using (var detail = new ProductDetailForm(id))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}