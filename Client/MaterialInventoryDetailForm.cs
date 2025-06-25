using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class MaterialInventoryDetailForm : Form
    {
        private string warehouseId;
        private string materialId;
        private bool isEditMode;

        public MaterialInventoryDetailForm(string warehouseId = null, string materialId = null)
        {
            InitializeComponent();

            this.warehouseId = warehouseId;
            this.materialId = materialId;
            this.isEditMode = (warehouseId != null && materialId != null);

            LoadComboBoxes();

            if (isEditMode)
            {
                LoadData();
                comboBoxWarehouseID.Enabled = false;
                comboBoxMaterialID.Enabled = false;
            }
        }

        private void LoadComboBoxes()
        {
            using (var cmd = new MySqlCommand("SELECT WarehouseID FROM Warehouse", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    comboBoxWarehouseID.Items.Add(reader.GetString("WarehouseID"));
            }

            using (var cmd = new MySqlCommand("SELECT MaterialID FROM Material", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    comboBoxMaterialID.Items.Add(reader.GetString("MaterialID"));
            }
        }

        private void LoadData()
        {
            var sql = @"SELECT MaterialQuantityInWarehouse, MinimumStockLevel, ReorderPoint
                        FROM Inventory_Material
                        WHERE WarehouseID = @wid AND MaterialID = @mid";

            using (var cmd = new MySqlCommand(sql, Program.Connection))
            {
                cmd.Parameters.AddWithValue("@wid", warehouseId);
                cmd.Parameters.AddWithValue("@mid", materialId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxWarehouseID.Text = warehouseId;
                        comboBoxMaterialID.Text = materialId;
                        numericUpDownQuantity.Value = reader.GetInt32("MaterialQuantityInWarehouse");
                        numericUpDownMinStock.Value = reader.GetInt32("MinimumStockLevel");
                        numericUpDownReorder.Value = reader.GetInt32("ReorderPoint");
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string wid = comboBoxWarehouseID.Text.Trim();
            string mid = comboBoxMaterialID.Text.Trim();
            int qty = (int)numericUpDownQuantity.Value;
            int min = (int)numericUpDownMinStock.Value;
            int reorder = (int)numericUpDownReorder.Value;

            if (string.IsNullOrEmpty(wid) || string.IsNullOrEmpty(mid))
            {
                MessageBox.Show("Please select both Warehouse and Material ID.");
                return;
            }

            string sql;
            if (isEditMode)
            {
                sql = @"UPDATE Inventory_Material
                        SET MaterialQuantityInWarehouse = @qty,
                            MinimumStockLevel = @min,
                            ReorderPoint = @reorder
                        WHERE WarehouseID = @wid AND MaterialID = @mid";
            }
            else
            {
                sql = @"INSERT INTO Inventory_Material (WarehouseID, MaterialID, MaterialQuantityInWarehouse, MinimumStockLevel, ReorderPoint)
                        VALUES (@wid, @mid, @qty, @min, @reorder)";
            }

            using (var cmd = new MySqlCommand(sql, Program.Connection))
            {
                cmd.Parameters.AddWithValue("@wid", wid);
                cmd.Parameters.AddWithValue("@mid", mid);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@min", min);
                cmd.Parameters.AddWithValue("@reorder", reorder);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Record saved successfully.");
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}