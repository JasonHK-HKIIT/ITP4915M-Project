using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class ViewPurchaseOrderLinesForm : Form
    {
        private readonly string purchaseOrderId;

        public ViewPurchaseOrderLinesForm(string purchaseOrderId)
        {
            InitializeComponent();
            this.purchaseOrderId = purchaseOrderId;
            LoadLines();
        }

        private void LoadLines()
        {
            string sql = @"
                SELECT pol.PurchaseOrderLineID, pol.MaterialID, m.MaterialName, pol.Quantity, pol.ReceivedQuantity
                FROM PurchaseOrderLine pol
                JOIN Material m ON pol.MaterialID = m.MaterialID
                WHERE pol.PurchaseOrderID = @poid
            ";

            using (var cmd = new MySqlCommand(sql, Program.Connection))
            {
                cmd.Parameters.AddWithValue("@poid", purchaseOrderId);
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns.Contains("Quantity"))
                        dataGridView1.Columns["Quantity"].DefaultCellStyle.Format = "N0";
                    if (dataGridView1.Columns.Contains("ReceivedQuantity"))
                        dataGridView1.Columns["ReceivedQuantity"].DefaultCellStyle.Format = "N0";
                }
            }
        }
    }
}
