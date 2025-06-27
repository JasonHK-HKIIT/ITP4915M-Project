using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class MaterialInventoryForm : Form
    {
        public MaterialInventoryForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;  // enable maximize if needed
            this.MinimizeBox = true;

            // Set form title (will appear in top-left)
            this.Text = "Material Inventory Form";
            this.Icon = Properties.Resources.Icon_Form;

            // Set UI font
            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);

            // Apply UI styles
            StyleButtons();
            StyleGrid();

            button1.Click += ButtonUpdate_Click;
            button2.Click += ButtonAdd_Click;
            button3.Click += ButtonDelete_Click;
            textBox1.KeyUp += TextBox1_KeyUp;
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
            ButtonStyle(button2, "Add Material", Color.CornflowerBlue);
            ButtonStyle(button3, "Delete Material", Color.IndianRed);
            
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
            string query = textBox1.Text.Trim();
            MySqlCommand command;

            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(
                    "SELECT WarehouseID, MaterialID, MaterialQuantityInWarehouse AS Quantity, MinimumStockLevel AS Minimum, ReorderPoint FROM Inventory_Material",
                    Program.Connection
                );
            }
            else
            {
                command = new MySqlCommand(
                    "SELECT WarehouseID, MaterialID, MaterialQuantityInWarehouse AS Quantity, MinimumStockLevel AS Minimum, ReorderPoint FROM Inventory_Material WHERE WarehouseID LIKE @search OR MaterialID LIKE @search",
                    Program.Connection
                );
                command.Parameters.AddWithValue("@search", "%" + query + "%");
            }

            var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load material inventory: " + ex.Message);
            }
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new MaterialInventoryDetailForm())
            {
                detail.Text = "Add Material Inventory";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];

            string warehouseId = row.Cells["WarehouseID"].Value.ToString();
            string materialId = row.Cells["MaterialID"].Value.ToString();

            using (var detail = new MaterialInventoryDetailForm(warehouseId, materialId))
            {
                detail.Text = "Update Material Inventory";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            string warehouseId = row.Cells["WarehouseID"].Value.ToString();
            string materialId = row.Cells["MaterialID"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete this material inventory record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var cmd = new MySqlCommand(
                    "DELETE FROM Inventory_Material WHERE WarehouseID=@wid AND MaterialID=@mid",
                    Program.Connection
                );
                cmd.Parameters.AddWithValue("@wid", warehouseId);
                cmd.Parameters.AddWithValue("@mid", materialId);

                try
                {
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message);
                }
            }
        }

        private void MaterialInventoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
