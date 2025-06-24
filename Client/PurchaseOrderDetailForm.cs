using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class PurchaseOrderDetailForm : Form
    {
        private Dictionary<string, string> materialDict = new();

        public PurchaseOrderDetailForm()
        {
            InitializeComponent();
            buttonSave.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            buttonCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            buttonAddLine.Click += ButtonAddLine_Click;
            buttonDeleteLine.Click += ButtonDeleteLine_Click;
            this.Load += PurchaseOrderDetailForm_Load;
        }

        public void SetFields(
            string poId, string supplierId, DateTime orderDate, DateTime deliveryDate,
            string status, string poStatus, List<PurchaseOrderLine> lines = null)
        {
            maskedTextBox1.Text = poId;
            comboBoxSupplier.SelectedValue = supplierId;
            dateTimePickerOrder.Value = orderDate;
            dateTimePickerDelivery.Value = deliveryDate;

            if (!comboBoxStatus.Items.Contains(status)) comboBoxStatus.Items.Add(status);
            comboBoxStatus.SelectedItem = status;

            if (!comboBoxPOStatus.Items.Contains(poStatus)) comboBoxPOStatus.Items.Add(poStatus);
            comboBoxPOStatus.SelectedItem = poStatus;

            if (lines != null)
            {
                var dt = (DataTable)dataGridViewLineItems.DataSource;
                if (dt == null) return;
                dt.Rows.Clear();
                foreach (var line in lines)
                {
                    dt.Rows.Add(line.MaterialID, line.MaterialName, line.Quantity, line.ReceivedQuantity);
                }
            }
        }

        public string PurchaseOrderID => maskedTextBox1.Text;
        public string SupplierID => comboBoxSupplier.SelectedValue?.ToString() ?? "";
        public DateTime OrderDate => dateTimePickerOrder.Value;
        public DateTime DeliveryDate => dateTimePickerDelivery.Value;
        public string Status => comboBoxStatus.SelectedItem?.ToString() ?? "";
        public string POStatus => comboBoxPOStatus.SelectedItem?.ToString() ?? "";

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
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0),
                    ReceivedQuantity = Convert.ToInt32(row.Cells["ReceivedQuantity"].Value ?? 0)
                });
            }
            return list;
        }

        private void PurchaseOrderDetailForm_Load(object sender, EventArgs e)
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

            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.AddRange(new object[] {
                "Ordered", "Pending", "Approved", "Processing", "Shipped", "Delivered", "Cancelled", "On Hold"
            });

            comboBoxPOStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPOStatus.Items.Clear();
            comboBoxPOStatus.Items.AddRange(new object[] {
                "In Transit", "Open", "Processing", "Partially Fulfilled", "Completed", "Closed", "Backordered", "Pending Review"
            });

            materialDict.Clear();
            using (var cmd = new MySqlCommand("SELECT MaterialID, MaterialName FROM Material", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader.GetString("MaterialID");
                    string name = reader.GetString("MaterialName");
                    materialDict[id] = name;
                }
            }

            var dtLines = new DataTable();
            dtLines.Columns.Add("MaterialID", typeof(string));
            dtLines.Columns.Add("MaterialName", typeof(string));
            dtLines.Columns.Add("Quantity", typeof(int));
            dtLines.Columns.Add("ReceivedQuantity", typeof(int));
            dataGridViewLineItems.DataSource = dtLines;

            if (dataGridViewLineItems.Columns.Contains("MaterialID"))
                dataGridViewLineItems.Columns.Remove("MaterialID");

            var comboCol = new DataGridViewComboBoxColumn
            {
                Name = "MaterialID",
                HeaderText = "MaterialID",
                DataSource = new BindingSource(materialDict, null),
                DisplayMember = "Key",
                ValueMember = "Key",
                DataPropertyName = "MaterialID"
            };
            dataGridViewLineItems.Columns.Insert(0, comboCol);

            dataGridViewLineItems.CellValueChanged += dataGridViewLineItems_CellValueChanged;
        }

        private void ButtonAddLine_Click(object sender, EventArgs e)
        {
            if (materialDict.Count > 0)
            {
                var first = materialDict.Keys.GetEnumerator();
                first.MoveNext();
                string matId = first.Current;
                ((DataTable)dataGridViewLineItems.DataSource).Rows.Add(matId, materialDict[matId], 1, 0);
            }
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
                if (materialDict.TryGetValue(matId, out string matName))
                {
                    dataGridViewLineItems.Rows[e.RowIndex].Cells["MaterialName"].Value = matName;
                }
            }
        }

        public class PurchaseOrderLine
        {
            public string MaterialID { get; set; }
            public string MaterialName { get; set; }
            public int Quantity { get; set; }
            public int ReceivedQuantity { get; set; }
        }
    }
}
