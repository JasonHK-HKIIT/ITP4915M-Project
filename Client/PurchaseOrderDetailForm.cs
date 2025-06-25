using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                DataPropertyName = "ReceivedQuantity"
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
    }
}
