using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class PurchaseOrderReportForm : Form
    {
        public PurchaseOrderReportForm()
        {
            InitializeComponent();
            LoadStatusCombo();
            btnEnter.Click += BtnEnter_Click;
            btnBack.Click += (s, e) => this.Close();
            // Show all results at startup
            LoadReport();
        }

        private void LoadStatusCombo()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            // Load unique statuses from database
            using (var cmd = new MySqlCommand("SELECT DISTINCT Status FROM PurchaseOrder ORDER BY Status", Program.Connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var status = reader.GetString(0);
                    if (!string.IsNullOrEmpty(status)) cmbStatus.Items.Add(status);
                }
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            string statusFilter = cmbStatus.SelectedItem?.ToString();
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            if (to < from) to = from; // Avoid invalid range

            string sql = @"SELECT 
                PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, Status, POStatus
                FROM PurchaseOrder
                WHERE OrderDate BETWEEN @from AND @to";
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                sql += " AND Status = @status";
            }
            sql += " ORDER BY OrderDate DESC";

            using (var cmd = new MySqlCommand(sql, Program.Connection))
            {
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                    cmd.Parameters.AddWithValue("@status", statusFilter);

                using (var da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.ClearSelection();
                    UpdateSummary(dt);
                }
            }
        }

        private void UpdateSummary(DataTable dt)
        {
            pnlSummary.Controls.Clear();
            int count = dt.Rows.Count;
            int totalQty = 0;
            foreach (DataRow row in dt.Rows)
            {
                // You can sum other numeric columns here if needed, e.g. total amount
                // Example: if you have Quantity column: totalQty += Convert.ToInt32(row["Quantity"]);
            }
            var lbl = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Fill,
                Text = $"Total Orders: {count}" //+ $", Total Qty: {totalQty}"
            };
            pnlSummary.Controls.Add(lbl);
        }
    }
}
