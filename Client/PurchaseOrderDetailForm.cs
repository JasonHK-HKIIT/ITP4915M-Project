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

        public void SetFields(
            string poId, string supplierId, DateTime orderDate, DateTime deliveryDate,
            string status, string poStatus, List<PurchaseOrderLine> lines = null)
        {
            maskedTextBox1.Text = poId;
            comboBoxSupplier.SelectedValue = supplierId;
            dateTimePickerOrder.Value = orderDate;
            dateTimePickerDelivery.Value = deliveryDate;

            if (!comboBoxStatus.Items.Contains(status))
                comboBoxStatus.Items.Add(status);
            comboBoxStatus.SelectedItem = status;

            if (!comboBoxPOStatus.Items.Contains(poStatus))
                comboBoxPOStatus.Items.Add(poStatus);
            comboBoxPOStatus.SelectedItem = poStatus;

            if (dataGridViewLineItems.DataSource == null)
            {
                var dt = new DataTable();
                dt.Columns.Add("MaterialID", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("ReceivedQuantity", typeof(int));
                dataGridViewLineItems.DataSource = dt;
            }

            if (lines != null)
            {
                var dt = (DataTable)dataGridViewLineItems.DataSource;
                dt.Rows.Clear();
                foreach (var line in lines)
                {
                    dt.Rows.Add(line.MaterialID, line.Quantity, line.ReceivedQuantity);
                }
            }
        }

        public string PurchaseOrderID => maskedTextBox1.Text;
        public string SupplierID => comboBoxSupplier.SelectedValue?.ToString() ?? "";
        public DateTime OrderDate => dateTimePickerOrder.Value;
        public DateTime DeliveryDate => dateTimePickerDelivery.Value;
        public string Status => comboBoxStatus.SelectedItem?.ToString() ?? comboBoxStatus.Text;
        public string POStatus => comboBoxPOStatus.SelectedItem?.ToString() ?? comboBoxPOStatus.Text;

        public DataGridView LineItemsGrid => dataGridViewLineItems;

        public List<PurchaseOrderLine> GetLineItems()
        {
            var list = new List<PurchaseOrderLine>();
            foreach (DataGridViewRow row in dataGridViewLineItems.Rows)
            {
                if (row.IsNewRow) continue;
                list.Add(new PurchaseOrderLine
                {
                    MaterialID = row.Cells["MaterialID"].Value?.ToString(),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0),
                    ReceivedQuantity = Convert.ToInt32(row.Cells["ReceivedQuantity"].Value ?? 0)
                });
            }
            return list;
        }

        private void PurchaseOrderDetailForm_Load(object sender, EventArgs e)
        {
            if (dataGridViewLineItems.DataSource == null)
            {
                var dt = new DataTable();
                dt.Columns.Add("MaterialID", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("ReceivedQuantity", typeof(int));
                dataGridViewLineItems.DataSource = dt;
            }

            using (var cmd = new MySqlCommand("SELECT SupplierID, SupplierName FROM Supplier", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBoxSupplier.DataSource = dt;
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierID";
            }

            comboBoxStatus.Items.Clear();
            using (var cmd = new MySqlCommand("SELECT DISTINCT Status FROM PurchaseOrder WHERE Status IS NOT NULL AND Status <> ''", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxStatus.Items.Add(reader.GetString(0));
                }
            }

            comboBoxPOStatus.Items.Clear();
            using (var cmd = new MySqlCommand("SELECT DISTINCT POStatus FROM PurchaseOrder WHERE POStatus IS NOT NULL AND POStatus <> ''", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxPOStatus.Items.Add(reader.GetString(0));
                }
            }
        }

        private void ButtonAddLine_Click(object sender, EventArgs e)
        {
            using (var cmd = new MySqlCommand("SELECT MaterialID FROM Material", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dtMat = new DataTable();
                adapter.Fill(dtMat);

                if (dtMat.Rows.Count > 0)
                {
                    string materialId = dtMat.Rows[0]["MaterialID"].ToString();
                    ((DataTable)dataGridViewLineItems.DataSource).Rows.Add(materialId, 1, 0);
                }
                else
                {
                    ((DataTable)dataGridViewLineItems.DataSource).Rows.Add("", 1, 0);
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

        public class PurchaseOrderLine
        {
            public string MaterialID { get; set; }
            public int Quantity { get; set; }
            public int ReceivedQuantity { get; set; }
        }
    }
}
