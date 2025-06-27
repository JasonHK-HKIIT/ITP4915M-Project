using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();

            // Restore default Windows form border
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;  // enable maximize if needed
            this.MinimizeBox = true;

            // Set form title (will appear in top-left)
            this.Text = "Product Inventory Form";
            this.Icon = Properties.Resources.Icon_Form;

            // Set UI font
            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);

            // Apply UI styles
            StyleButtons();
            StyleGrid();

            button1.Click += ButtonUpdate_Click;   // "Update Inventory"
            button2.Click += ButtonAdd_Click;      // "Add Product"
            button3.Click += ButtonDelete_Click;   // "Delete Selected"
            textBox1.KeyUp += textBox1_KeyUp;      // Search on Enter
            LoadData();
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
            ButtonStyle(button1, "Update Inventory", Color.MediumSeaGreen);
            ButtonStyle(button2, "Add Product", Color.CornflowerBlue);
            ButtonStyle(button3, "Delete Selected", Color.IndianRed);
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

        /// <summary>
        /// Loads inventory from database, filtered if needed.
        /// </summary>
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            MySqlCommand command;

            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(
                    "SELECT WarehouseID AS Warehouse, ProductID AS Product, ProductQuantityInWarehouse AS Quantity, MinimumStockLevel AS Minimum, ReorderPoint FROM Inventory_Product",
                    Program.Connection
                );
            }
            else
            {
                command = new MySqlCommand(
                    @"SELECT WarehouseID AS Warehouse, ProductID AS Product, ProductQuantityInWarehouse AS Quantity, 
                     MinimumStockLevel AS Minimum, ReorderPoint 
              FROM Inventory_Product 
              WHERE WarehouseID LIKE @search OR ProductID LIKE @search",
                    Program.Connection
                );
                command.Parameters.AddWithValue("@search", $"%{query}%");
            }

            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new InventoryDetailForm())
            {
                detail.Text = "Add Product to Warehouse";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    // Insert to DB
                    var cmd = new MySqlCommand(
                        @"INSERT INTO Inventory_Product 
                            (WarehouseID, ProductID, ProductQuantityInWarehouse, MinimumStockLevel, ReorderPoint) 
                          VALUES 
                            (@w, @p, @q, @min, @r)",
                        Program.Connection
                    );
                    cmd.Parameters.AddWithValue("@w", detail.Warehouse);
                    cmd.Parameters.AddWithValue("@p", detail.Product);
                    cmd.Parameters.AddWithValue("@q", detail.Quantity);
                    cmd.Parameters.AddWithValue("@min", detail.MinimumStock);
                    cmd.Parameters.AddWithValue("@r", detail.ReorderPoint);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insert failed: " + ex.Message, "Error");
                    }
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];

            string warehouse = row.Cells["Warehouse"].Value.ToString();
            string product = row.Cells["Product"].Value.ToString();
            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

            object minObj = row.Cells["Minimum"].Value;
            int min = (minObj == null || minObj == DBNull.Value) ? 0 : Convert.ToInt32(minObj);

            object reorderObj = row.Cells["ReorderPoint"].Value;
            int reorder = (reorderObj == null || reorderObj == DBNull.Value) ? 0 : Convert.ToInt32(reorderObj);

            using (var detail = new InventoryDetailForm())
            {
                detail.Text = "Update Inventory";
                detail.SetFields(warehouse, product, quantity, reorder, min);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    var cmd = new MySqlCommand(
                        @"UPDATE Inventory_Product 
                  SET ProductQuantityInWarehouse=@q, MinimumStockLevel=@min, ReorderPoint=@r
                  WHERE WarehouseID=@w AND ProductID=@p",
                        Program.Connection
                    );
                    cmd.Parameters.AddWithValue("@q", detail.Quantity);
                    cmd.Parameters.AddWithValue("@min", detail.MinimumStock);
                    cmd.Parameters.AddWithValue("@r", detail.ReorderPoint);
                    cmd.Parameters.AddWithValue("@w", warehouse);
                    cmd.Parameters.AddWithValue("@p", product);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update failed: " + ex.Message, "Error");
                    }
                }
            }
        }


        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];
            string warehouse = row.Cells["Warehouse"].Value.ToString();
            string product = row.Cells["Product"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete this inventory record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var cmd = new MySqlCommand(
                    @"DELETE FROM Inventory_Product WHERE WarehouseID=@w AND ProductID=@p",
                    Program.Connection
                );
                cmd.Parameters.AddWithValue("@w", warehouse);
                cmd.Parameters.AddWithValue("@p", product);

                try
                {
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message, "Error");
                }
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
