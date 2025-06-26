using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class CustomerOrderReportForm : Form
    {
        public CustomerOrderReportForm()
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
            using (var cmd = new MySqlCommand("SELECT DISTINCT Status FROM CustomerOrder ORDER BY Status", Program.Connection))
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
            if (to < from) to = from; // Prevent invalid range

            string sql = @"SELECT 
                CustomerOrderID, CustomerID, QuotationID, OrderDate, Deadline, Status, DepositPaid, BalanceDue, PaymentStatus, OrderType, TotalAmount
                FROM CustomerOrder
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
            decimal totalAmount = 0;
            decimal totalDeposit = 0;
            decimal totalBalanceDue = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["TotalAmount"] != DBNull.Value)
                    totalAmount += Convert.ToDecimal(row["TotalAmount"]);
                if (row["DepositPaid"] != DBNull.Value)
                    totalDeposit += Convert.ToDecimal(row["DepositPaid"]);
                if (row["BalanceDue"] != DBNull.Value)
                    totalBalanceDue += Convert.ToDecimal(row["BalanceDue"]);
            }

            var lbl = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Fill,
                Text =
                    $"Total Orders: {count}, " +
                    $"Total Amount: {totalAmount:C}\n" +
                    $"Total Deposit Paid: {totalDeposit:C}, " +
                    $"Total Balance Due: {totalBalanceDue:C}"
            };
            pnlSummary.Controls.Add(lbl);
        }

    }
}
