using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class PurchaseOrderDetailForm : Form
    {
        public PurchaseOrderDetailForm()
        {
            InitializeComponent();
            buttonSave.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            buttonCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            buttonAddLine.Click += ButtonAddLine_Click;
            buttonDeleteLine.Click += ButtonDeleteLine_Click;
            this.Load += PurchaseOrderDetailForm_Load;
        }

        // Pre-fill form fields for Edit
        public void SetFields(
            string poId, string supplierId, DateTime orderDate, DateTime deliveryDate,
            string status, string poStatus, List<PurchaseOrderLine> lines = null
        )
        {
            textBoxPOID.Text = poId;
            comboBoxSupplier.SelectedValue = supplierId;
            dateTimePickerOrder.Value = orderDate;
            dateTimePickerDelivery.Value = deliveryDate;

            // Ensure the status exists in comboBoxStatus before selecting
            if (!comboBoxStatus.Items.Contains(status))
                comboBoxStatus.Items.Add(status);
            comboBoxStatus.SelectedItem = status;

            // Ensure the PO status exists in comboBoxPOStatus before selecting
            if (!comboBoxPOStatus.Items.Contains(poStatus))
                comboBoxPOStatus.Items.Add(poStatus);
            comboBoxPOStatus.SelectedItem = poStatus;

            // Load existing line items if provided
            if (lines != null)
            {
                var dt = (DataTable)dataGridViewLineItems.DataSource;
                dt.Rows.Clear();
                foreach (var line in lines)
                {
                    dt.Rows.Add(line.MaterialID, line.MaterialName, line.Quantity, line.ReceivedQuantity);
                }
            }
        }

        // Expose properties to read form data
        public string PurchaseOrderID => textBoxPOID.Text;
        public string SupplierID => comboBoxSupplier.SelectedValue?.ToString() ?? "";
        public DateTime OrderDate => dateTimePickerOrder.Value;
        public DateTime DeliveryDate => dateTimePickerDelivery.Value;
        public string Status => comboBoxStatus.SelectedItem?.ToString() ?? comboBoxStatus.Text;
        public string POStatus => comboBoxPOStatus.SelectedItem?.ToString() ?? comboBoxPOStatus.Text;

        // Line items as DataGridView
        public DataGridView LineItemsGrid => dataGridViewLineItems;

        // Optionally: Get line items as a strongly typed list
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
            // --- Fill Supplier ComboBox from DB ---
            using (var cmd = new MySqlCommand("SELECT SupplierID, SupplierName FROM Supplier", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxSupplier.DataSource = dt;
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierID";
            }

            // --- Fill Status from DB ---
            comboBoxStatus.Items.Clear();
            using (var cmd = new MySqlCommand("SELECT DISTINCT Status FROM PurchaseOrder WHERE Status IS NOT NULL AND Status <> ''", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxStatus.Items.Add(reader.GetString(0));
                }
            }

            // --- Fill POStatus from DB ---
            comboBoxPOStatus.Items.Clear();
            using (var cmd = new MySqlCommand("SELECT DISTINCT POStatus FROM PurchaseOrder WHERE POStatus IS NOT NULL AND POStatus <> ''", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxPOStatus.Items.Add(reader.GetString(0));
                }
            }

            // --- Line Items Grid Setup (if not already) ---
            if (dataGridViewLineItems.Columns.Count == 0)
            {
                var dtLines = new DataTable();
                dtLines.Columns.Add("MaterialID", typeof(string));
                dtLines.Columns.Add("MaterialName", typeof(string));
                dtLines.Columns.Add("Quantity", typeof(int));
                dtLines.Columns.Add("ReceivedQuantity", typeof(int));
                dataGridViewLineItems.DataSource = dtLines;
            }
        }

        private void ButtonAddLine_Click(object sender, EventArgs e)
        {
            using (var cmd = new MySqlCommand("SELECT MaterialID, MaterialName FROM Material", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dtMat = new DataTable();
                adapter.Fill(dtMat);

                if (dtMat.Rows.Count > 0)
                {
                    var firstMat = dtMat.Rows[0];
                    ((DataTable)dataGridViewLineItems.DataSource).Rows.Add(
                        firstMat["MaterialID"].ToString(),
                        firstMat["MaterialName"].ToString(),
                        1, // default Quantity
                        0  // default ReceivedQuantity
                    );
                }
                else
                {
                    ((DataTable)dataGridViewLineItems.DataSource).Rows.Add("", "", 1, 0);
                }
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

        // Model class for line items
        public class PurchaseOrderLine
        {
            public string MaterialID { get; set; }
            public string MaterialName { get; set; }
            public int Quantity { get; set; }
            public int ReceivedQuantity { get; set; }
        }
    }
}
