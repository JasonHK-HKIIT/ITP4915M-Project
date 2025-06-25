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
            button1.Click += ButtonUpdate_Click;
            button2.Click += ButtonAdd_Click;
            button3.Click += ButtonDelete_Click;
            textBox1.KeyUp += TextBox1_KeyUp;
            LoadData();
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
    }
}
