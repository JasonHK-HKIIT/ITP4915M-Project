using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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
                PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, Status
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
                    // Update summary using the current filtered range
                    UpdateSummary(from, to, statusFilter);
                }
            }
        }

        private void UpdateSummary(DateTime from, DateTime to, string statusFilter)
        {
            pnlSummary.Controls.Clear();

            // 1. Find all PurchaseOrderIDs in filtered range and status
            List<string> poIDs = new List<string>();
            string poSql = @"SELECT PurchaseOrderID FROM PurchaseOrder 
                        WHERE OrderDate BETWEEN @from AND @to";
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                poSql += " AND Status = @status";

            using (var cmd = new MySqlCommand(poSql, Program.Connection))
            {
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                    cmd.Parameters.AddWithValue("@status", statusFilter);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        poIDs.Add(reader.GetString(0));
                }
            }

            if (poIDs.Count == 0)
            {
                var lbl = new Label
                {
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    Text = "No purchase orders in the selected range."
                };
                pnlSummary.Controls.Add(lbl);
                return;
            }

            // 2. Query: sum quantities and calculate total price for each material
            string inClause = string.Join(",", poIDs.ConvertAll(id => $"'{MySqlHelper.EscapeString(id)}'"));
            string sumSql = $@"
        SELECT m.MaterialName, SUM(pol.Quantity) AS TotalQty, m.PricePerUnit,
               (SUM(pol.Quantity) * m.PricePerUnit) AS TotalPrice
        FROM PurchaseOrderLine pol
        JOIN Material m ON pol.MaterialID = m.MaterialID
        WHERE pol.PurchaseOrderID IN ({inClause})
        GROUP BY m.MaterialName, m.PricePerUnit
        ORDER BY m.MaterialName;";

            var summaryRows = new List<(string name, int qty, decimal pricePerUnit, decimal totalPrice)>();
            int grandQty = 0;
            decimal grandTotalPrice = 0;

            using (var cmd = new MySqlCommand(sumSql, Program.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string matName = reader["MaterialName"].ToString();
                        int qty = reader["TotalQty"] != DBNull.Value ? Convert.ToInt32(reader["TotalQty"]) : 0;
                        decimal pricePerUnit = reader["PricePerUnit"] != DBNull.Value ? Convert.ToDecimal(reader["PricePerUnit"]) : 0;
                        decimal totalPrice = reader["TotalPrice"] != DBNull.Value ? Convert.ToDecimal(reader["TotalPrice"]) : 0;
                        summaryRows.Add((matName, qty, pricePerUnit, totalPrice));
                        grandQty += qty;
                        grandTotalPrice += totalPrice;
                    }
                }
            }

            // 3. Build TableLayoutPanel
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                AutoScroll = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                AutoSize = true
            };
            table.RowStyles.Clear();

            // Header row
            table.RowCount = 1;
            table.Controls.Add(new Label
            {
                Text = "Material",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 0, 0);
            table.Controls.Add(new Label
            {
                Text = "Total Quantity",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 1, 0);
            table.Controls.Add(new Label
            {
                Text = "Price Per Unit",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 2, 0);
            table.Controls.Add(new Label
            {
                Text = "Total Price",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 3, 0);

            // Data rows
            int row = 1;
            foreach (var (name, qty, pricePerUnit, totalPrice) in summaryRows)
            {
                table.RowCount = row + 1;
                table.Controls.Add(new Label
                {
                    Text = name,
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    Padding = new Padding(2)
                }, 0, row);
                table.Controls.Add(new Label
                {
                    Text = qty.ToString(),
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    Padding = new Padding(2)
                }, 1, row);
                table.Controls.Add(new Label
                {
                    Text = pricePerUnit.ToString("C"),
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    Padding = new Padding(2)
                }, 2, row);
                table.Controls.Add(new Label
                {
                    Text = totalPrice.ToString("C"),
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    Padding = new Padding(2)
                }, 3, row);
                row++;
            }

            // Grand total row
            table.RowCount = row + 1;
            table.Controls.Add(new Label
            {
                Text = "Grand Total:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 0, row);
            table.Controls.Add(new Label
            {
                Text = grandQty.ToString(),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 1, row);
            table.Controls.Add(new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 2, row);
            table.Controls.Add(new Label
            {
                Text = grandTotalPrice.ToString("C"),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(2)
            }, 3, row);

            pnlSummary.Controls.Add(table);
        }


    }
}
