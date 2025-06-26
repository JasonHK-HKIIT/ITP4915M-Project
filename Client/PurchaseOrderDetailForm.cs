using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Formats.Tar;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class PurchaseOrderDetailForm : Form
    {
        private Dictionary<string, (string Name, string Description)> materialDict = new();

        // ✅ Public properties for use in Add/Edit logic
        public string PurchaseOrderID => maskedTextBox1.Text;
        public string SupplierID => comboBoxSupplier.SelectedValue?.ToString() ?? "";
        public DateTime OrderDate => dateTimePickerOrder.Value;
        public DateTime DeliveryDate => dateTimePickerDelivery.Value;
        public string Status => (string)comboBoxStatus.SelectedItem;
        public string POStatus => (string)comboBoxPOStatus.SelectedItem;

        public PurchaseOrderDetailForm()
        {
            InitializeComponent();
            LoadMaterials();
            LoadSuppliers();

            comboBoxStatus.SelectedIndex = 0;
            comboBoxPOStatus.SelectedIndex = 0;

            buttonSave.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            buttonCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            buttonAddLine.Click += ButtonAddLine_Click;
            buttonDeleteLine.Click += ButtonDeleteLine_Click;
        }

        private void LoadSuppliers()
        {
            using (var cmd = new MySqlCommand("SELECT SupplierID, SupplierName FROM Supplier", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxSupplier.DataSource = dt;
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierID";
            }
        }

        private void LoadMaterials()
        {
            materialDict.Clear();
            using (var cmd = new MySqlCommand("SELECT MaterialID, MaterialName, Description FROM Material", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader.GetString("MaterialID");
                    string name = reader.GetString("MaterialName");
                    string desc = reader.GetString("Description");
                    materialDict[id] = (name, desc);
                }
            }

            // Create DataTable for DataGridView
            var dtLines = new DataTable();
            dtLines.Columns.Add("MaterialID", typeof(string));
            dtLines.Columns.Add("MaterialName", typeof(string));
            dtLines.Columns.Add("Description", typeof(string));
            dtLines.Columns.Add("Quantity", typeof(int));
            dtLines.Columns.Add("ReceivedQuantity", typeof(int));

            dataGridViewLineItems.AutoGenerateColumns = false;
            dataGridViewLineItems.Columns.Clear();

            // ComboBox column
            var comboCol = new DataGridViewComboBoxColumn
            {
                Name = "MaterialID",
                HeaderText = "Material ID",
                DataPropertyName = "MaterialID",
                DropDownWidth = 150,
                Width = 100,
                FlatStyle = FlatStyle.Flat,
                DataSource = materialDict.Keys.ToList()
            };
            dataGridViewLineItems.Columns.Add(comboCol);

            // Text columns with DataPropertyName
            var nameCol = new DataGridViewTextBoxColumn
            {
                Name = "MaterialName",
                HeaderText = "Material Name",
                DataPropertyName = "MaterialName",
                ReadOnly = true
            };
            var descCol = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                DataPropertyName = "Description",
                ReadOnly = true
            };
            var qtyCol = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            };
            var recvQtyCol = new DataGridViewTextBoxColumn
            {
                Name = "ReceivedQuantity",
                HeaderText = "Received Quantity",
                DataPropertyName = "ReceivedQuantity",
                //ReadOnly = false
            };

            dataGridViewLineItems.Columns.Add(nameCol);
            dataGridViewLineItems.Columns.Add(descCol);
            dataGridViewLineItems.Columns.Add(qtyCol);
            dataGridViewLineItems.Columns.Add(recvQtyCol);

            // Set the data source after columns are ready
            dataGridViewLineItems.DataSource = dtLines;

            dataGridViewLineItems.CellValueChanged += dataGridViewLineItems_CellValueChanged;
            dataGridViewLineItems.DataError += (s, args) =>
            {
                MessageBox.Show("Please select a valid Material ID.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                args.ThrowException = false;
            };
        }

        public void SetFields(string poId, string supplierId, DateTime orderDate, DateTime deliveryDate, string status, string poStatus, List<PurchaseOrderLine> lines = null)
        {
            maskedTextBox1.Text = poId;
            comboBoxSupplier.SelectedValue = supplierId;
            dateTimePickerOrder.Value = orderDate;
            dateTimePickerDelivery.Value = deliveryDate;

            if (comboBoxStatus.Items.Contains(status))
                comboBoxStatus.SelectedItem = status;
            if (comboBoxPOStatus.Items.Contains(poStatus))
                comboBoxPOStatus.SelectedItem = poStatus;

            if (lines != null)
            {
                var dt = (DataTable)dataGridViewLineItems.DataSource;
                dt.Rows.Clear();

                foreach (var line in lines)
                {
                    // Use values from line object, fall back to dictionary if empty
                    string name = !string.IsNullOrEmpty(line.MaterialName) ? line.MaterialName :
                                  (materialDict.TryGetValue(line.MaterialID, out var val) ? val.Name : "");
                    string desc = !string.IsNullOrEmpty(line.Description) ? line.Description :
                                  (materialDict.TryGetValue(line.MaterialID, out var val2) ? val2.Description : "");

                    dt.Rows.Add(
                        line.MaterialID ?? "",
                        name ?? "",
                        desc ?? "",
                        line.Quantity,
                        line.ReceivedQuantity
                    );
                }
            }
        }

        public List<PurchaseOrderLine> GetLineItems()
        {
            var list = new List<PurchaseOrderLine>();
            foreach (DataGridViewRow row in dataGridViewLineItems.Rows)
            {
                if (row.IsNewRow) continue;
                list.Add(new PurchaseOrderLine
                {
                    MaterialID = row.Cells["MaterialID"].Value?.ToString(),
                    MaterialName = row.Cells["MaterialName"].Value?.ToString(),
                    Description = row.Cells["Description"].Value?.ToString(),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0),
                    ReceivedQuantity = Convert.ToInt32(row.Cells["ReceivedQuantity"].Value ?? 0)
                });
            }
            return list;
        }

        private void ButtonAddLine_Click(object sender, EventArgs e)
        {
            ((DataTable)dataGridViewLineItems.DataSource).Rows.Add("", "", "", 1, 0);
        }

        private void ButtonDeleteLine_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewLineItems.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridViewLineItems.Rows.RemoveAt(row.Index);
            }
        }

        private void dataGridViewLineItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewLineItems.Columns[e.ColumnIndex].Name == "MaterialID")
            {
                var matId = dataGridViewLineItems.Rows[e.RowIndex].Cells["MaterialID"].Value?.ToString();
                if (materialDict.TryGetValue(matId, out var mat))
                {
                    dataGridViewLineItems.Rows[e.RowIndex].Cells["MaterialName"].Value = mat.Name;
                    dataGridViewLineItems.Rows[e.RowIndex].Cells["Description"].Value = mat.Description;
                }
                else
                {
                    dataGridViewLineItems.Rows[e.RowIndex].Cells["MaterialName"].Value = "";
                    dataGridViewLineItems.Rows[e.RowIndex].Cells["Description"].Value = "";
                }
            }
        }

        public class PurchaseOrderLine
        {
            public string MaterialID { get; set; }
            public string MaterialName { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public int ReceivedQuantity { get; set; }
        }

        private void PurchaseOrderDetailForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewLineItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bool isDelivered = POStatus == "Delivered";
            //dataGridViewLineItems.Columns["ReceivedQuantity"].ReadOnly = !isDelivered;
        }


        private void UpdatePOStatus()
        {
            bool allComplete = true;
            bool anyPartial = false;

            foreach (var line in GetLineItems())
            {
                if (line.ReceivedQuantity > 0 && line.ReceivedQuantity < line.Quantity)
                {
                    anyPartial = true;
                    break;
                }
                if (line.ReceivedQuantity != line.Quantity || line.Quantity == 0)
                {
                    allComplete = false;
                }
            }

            // 更新 UI 的 Status
            if (anyPartial)
            {
                comboBoxStatus.SelectedItem = "Partial Completed";
            }
            else if (allComplete)
            {
                comboBoxStatus.SelectedItem = "Completed";
            }
            else
            {
                comboBoxStatus.SelectedItem = "Processing";
            }

            // Update Database
            var command = new MySqlCommand(
                "UPDATE `purchaseorder` SET `Status` = @status  WHERE PurchaseOrderID=@poid", Program.Connection);
            command.Parameters.AddWithValue("@status", Status);
            command.Parameters.AddWithValue("@poid", PurchaseOrderID);
            command.ExecuteNonQuery();

        }

        private List<int> UpdatePOLine()
        {
            var deltaQuantities = new List<int>();
            foreach (var line in GetLineItems())
            {
                // 驗證 ReceivedQuantity 不超過 Quantity
                if (line.ReceivedQuantity > line.Quantity)
                {
                    MessageBox.Show($"Received quantity ({line.ReceivedQuantity}) cannot exceed order quantity ({line.Quantity}) for material {line.MaterialID}.",
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    deltaQuantities.Add(0);
                    line.ReceivedQuantity = 0;
                }
                else
                {
                    // 獲取舊的 ReceivedQuantity
                    var selectCmd = new MySqlCommand(
                        "SELECT ReceivedQuantity FROM purchaseorderline WHERE PurchaseOrderID=@poid AND MaterialID=@mid",
                        Program.Connection);
                    selectCmd.Parameters.AddWithValue("@poid", PurchaseOrderID);
                    selectCmd.Parameters.AddWithValue("@mid", line.MaterialID);
                    var reader = selectCmd.ExecuteReader();
                    int oldReceivedQty = reader.Read() ? reader.GetInt32("ReceivedQuantity") : 0;
                    reader.Close();

                    // 計算增量
                    int deltaQty = line.ReceivedQuantity - oldReceivedQty;
                    deltaQuantities.Add(deltaQty);

                    // 更新 PurchaseOrderLine
                    var updateLineCmd = new MySqlCommand(
                        "UPDATE purchaseorderline SET ReceivedQuantity=@rcvqty WHERE PurchaseOrderID=@poid AND MaterialID=@mid",
                        Program.Connection);
                    updateLineCmd.Parameters.AddWithValue("@poid", PurchaseOrderID);
                    updateLineCmd.Parameters.AddWithValue("@mid", line.MaterialID);
                    updateLineCmd.Parameters.AddWithValue("@rcvqty", line.ReceivedQuantity);
                    int rowsAffected = updateLineCmd.ExecuteNonQuery();

                    // 如果沒有更新到記錄（可能是新行），則插入
                    if (rowsAffected == 0)
                    {
                        var insertLineCmd = new MySqlCommand(
                            "INSERT INTO purchaseorderline (PurchaseOrderID, MaterialID, Quantity, ReceivedQuantity) VALUES (@poid, @mid, @qty, @rcvqty)",
                            Program.Connection);
                        insertLineCmd.Parameters.AddWithValue("@poid", PurchaseOrderID);
                        insertLineCmd.Parameters.AddWithValue("@mid", line.MaterialID);
                        insertLineCmd.Parameters.AddWithValue("@qty", line.Quantity);
                        insertLineCmd.Parameters.AddWithValue("@rcvqty", line.ReceivedQuantity);
                        insertLineCmd.ExecuteNonQuery();
                    }
                }
            }
            return deltaQuantities;
        }

        private void UpdateInventory(List<int> deltaQuantities)
        {
            //********************* change to combox.Text
            var wid = "WH002";
            //*********************

            var lines = GetLineItems();
            for (int i = 0; i < lines.Count && i < deltaQuantities.Count; i++)
            {
                var line = lines[i];
                int deltaQty = deltaQuantities[i];
                if (deltaQty == 0)
                    continue;

                // 檢查 Inventory_Material 是否有記錄
                var checkInventoryCmd = new MySqlCommand(
                    "SELECT MaterialQuantityInWarehouse FROM inventory_material WHERE WarehouseID=@wid AND MaterialID=@mid",
                    Program.Connection);
                checkInventoryCmd.Parameters.AddWithValue("@wid", wid);
                checkInventoryCmd.Parameters.AddWithValue("@mid", line.MaterialID);
                var reader = checkInventoryCmd.ExecuteReader();
                bool hasRecord = reader.Read();
                int currentQty = hasRecord ? reader.GetInt32("MaterialQuantityInWarehouse") : 0;
                reader.Close();

                // 更新 inventory_material 表
                var updateInventoryCmd = new MySqlCommand(
                        "UPDATE inventory_material SET MaterialQuantityInWarehouse=@newqty WHERE WarehouseID=@wid AND MaterialID=@mid",
                        Program.Connection);
                updateInventoryCmd.Parameters.AddWithValue("@wid", wid);
                updateInventoryCmd.Parameters.AddWithValue("@mid", line.MaterialID);
                updateInventoryCmd.Parameters.AddWithValue("@newqty", currentQty + deltaQty);
                updateInventoryCmd.ExecuteNonQuery();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SupplierID))
            {
                MessageBox.Show("Please Choose Supplier", "Valid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lines = GetLineItems();
            if (!lines.Any())
            {
                MessageBox.Show("Please import at least 1 order line", "Valid Inpu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var deltaQuantities = UpdatePOLine();
            UpdatePOStatus();
            UpdateInventory(deltaQuantities);

        }

        private void dateTimePickerDelivery_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerOrder_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelPOStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
