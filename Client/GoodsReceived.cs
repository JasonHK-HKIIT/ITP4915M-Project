using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class GoodsReceivedForm : Form
    {
        public GoodsReceivedForm()
        {
            InitializeComponent();
            buttonSearch.Click += buttonSearch_Click;
            buttonSave.Click += buttonSave_Click;
            buttonClose.Click += (s, e) => this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string poId = textBoxPurchaseOrderID.Text.Trim();

            foreach (DataGridViewRow row in dataGridViewMaterials.Rows)
            {
                if (row.IsNewRow) continue;

                string materialId = row.Cells["MaterialID"].Value?.ToString();
                int receiveNow = 0;
                int alreadyReceived = Convert.ToInt32(row.Cells["ReceivedQuantity"].Value ?? 0);
                int ordered = Convert.ToInt32(row.Cells["OrderedQuantity"].Value ?? 0);

                // Try to get the user's input for "ReceiveNow"
                int.TryParse(row.Cells["ReceiveNow"].Value?.ToString(), out receiveNow);

                // Validation: do not receive more than ordered
                if (receiveNow < 0 || alreadyReceived + receiveNow > ordered)
                {
                    MessageBox.Show($"Invalid receive qty for material {materialId}.");
                    return;
                }

                if (receiveNow > 0)
                {
                    // 1. Update PurchaseOrderLine.ReceivedQuantity
                    var updateCmd = new MySqlCommand(@"
                UPDATE PurchaseOrderLine 
                SET ReceivedQuantity = ReceivedQuantity + @receiveNow 
                WHERE PurchaseOrderID = @poid AND MaterialID = @mid",
                        Program.Connection);
                    updateCmd.Parameters.AddWithValue("@poid", poId);
                    updateCmd.Parameters.AddWithValue("@mid", materialId);
                    updateCmd.Parameters.AddWithValue("@receiveNow", receiveNow);
                    updateCmd.ExecuteNonQuery();

                    // 2. Update Inventory_Material.Quantity
                    var invCmd = new MySqlCommand(@"
                UPDATE Inventory_Material
                SET Quantity = Quantity + @receiveNow
                WHERE MaterialID = @mid",
                        Program.Connection);
                    invCmd.Parameters.AddWithValue("@mid", materialId);
                    invCmd.Parameters.AddWithValue("@receiveNow", receiveNow);
                    invCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Goods received and inventory updated!");
            this.Close();
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string poId = textBoxPurchaseOrderID.Text.Trim();

            // Create table structure
            var dt = new DataTable();
            dt.Columns.Add("MaterialID", typeof(string));
            dt.Columns.Add("MaterialName", typeof(string));
            dt.Columns.Add("OrderedQuantity", typeof(int));
            dt.Columns.Add("ReceivedQuantity", typeof(int));
            dt.Columns.Add("ReceiveNow", typeof(int));

            // Query all PO lines and material names for this PO
            using (var cmd = new MySqlCommand(@"
        SELECT pol.MaterialID, m.MaterialName, pol.Quantity AS OrderedQuantity, pol.ReceivedQuantity
        FROM PurchaseOrderLine pol
        JOIN Material m ON pol.MaterialID = m.MaterialID
        WHERE pol.PurchaseOrderID = @poid", Program.Connection))
            {
                cmd.Parameters.AddWithValue("@poid", poId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(
                            reader["MaterialID"].ToString(),
                            reader["MaterialName"].ToString(),
                            Convert.ToInt32(reader["OrderedQuantity"]),
                            Convert.ToInt32(reader["ReceivedQuantity"]),
                            0 // Default ReceiveNow to 0
                        );
                    }
                }
            }

            dataGridViewMaterials.DataSource = dt;

            // Set readonly and editable columns
            foreach (DataGridViewColumn col in dataGridViewMaterials.Columns)
            {
                if (col.Name == "ReceiveNow")
                    col.ReadOnly = false;
                else
                    col.ReadOnly = true;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoodsReceivedForm_Load(object sender, EventArgs e)
        {

        }
    }
}
