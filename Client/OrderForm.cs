using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();

            // ─── Standard form chrome ─────────────────────────────
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Text = "OrderForm";
            this.Icon = Properties.Resources.Icon_Form;

            // ─── Font cascade (Helvetica → Segoe UI fallback) ─────
            Font uiFont;
            try { uiFont = new Font("Helvetica", 10); }
            catch { uiFont = new Font("Segoe UI", 10); }
            ApplyFont(this, uiFont);

            // ─── Style buttons & grid ─────────────────────────────
            StyleButtons();
            StyleGrid();

            // ─── Hook up events ───────────────────────────────────
            button3.Click += ButtonAdd_Click;   // Add
            button2.Click += ButtonEdit_Click;  // Edit
            textBox1.KeyUp += TextBoxSearch_KeyUp;

            LoadData(); // initial load
        }

        /*──────────────────────────────────────────────────────────
         *  UI-STYLE HELPERS (copied from CustomerForm.cs)
         * ─────────────────────────────────────────────────────────*/
        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Font = font;
                if (ctrl.HasChildren) ApplyFont(ctrl, font);
            }
        }

        private void StyleButtons()
        {
            if (button3 != null) ButtonStyle(button3, "Add Order", Color.MediumSeaGreen); // ✅
            if (button2 != null) ButtonStyle(button2, "Edit Order", Color.CornflowerBlue); // ✏️
            // No delete button in this form
        }

        private static void ButtonStyle(Button btn, string text, Color backColor)
        {
            btn.Text = text;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }

        private void StyleGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = this.Font;
        }

        /*──────────────────────────────────────────────────────────
         *  SEARCH & LOAD
         * ─────────────────────────────────────────────────────────*/
        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) LoadData(); }

        private void LoadData()
        {
            string q = textBox1.Text.Trim();

            string sql = @"
                SELECT
                    o.CustomerOrderID,
                    c.CustomerName,
                    o.QuotationID,
                    o.OrderDate,
                    o.Deadline,
                    o.Status,
                    o.DepositPaid,
                    o.BalanceDue,
                    o.TotalAmount,
                    o.PaymentStatus,
                    o.OrderType
                FROM CustomerOrder o
                LEFT JOIN Customer c ON o.CustomerID = c.CustomerID";

            using var cmd = new MySqlCommand(sql, Program.Connection);

            if (!string.IsNullOrEmpty(q))
            {
                sql += @"
                    WHERE
                        o.CustomerOrderID LIKE @q OR
                        c.CustomerName     LIKE @q OR
                        o.QuotationID      LIKE @q OR
                        o.Status           LIKE @q OR
                        o.PaymentStatus    LIKE @q";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@q", $"%{q}%");
            }

            using var adp = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            try
            {
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders:\n{ex.Message}",
                                "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*──────────────────────────────────────────────────────────
         *  ADD ORDER
         * ─────────────────────────────────────────────────────────*/
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using var detail = new OrderDetailForm { Text = "Add Order" };
            if (detail.ShowDialog() != DialogResult.OK) return;

            var lastCmd = new MySqlCommand(
                "SELECT CustomerOrderID FROM CustomerOrder ORDER BY CustomerOrderID DESC LIMIT 1",
                Program.Connection);
            var last = lastCmd.ExecuteScalar() as string ?? "ORD000";
            int next = int.Parse(last.Substring(3)) + 1;

            using var cmd = new MySqlCommand(@"
                INSERT INTO CustomerOrder
                    (CustomerOrderID, CustomerID, QuotationID, OrderDate, Deadline,
                     Status, DepositPaid, BalanceDue, TotalAmount, PaymentStatus, OrderType)
                VALUES
                    (@id, @custId, @quoId, @oDate, @deadline,
                     @status, @deposit, @balance, @total, @payStatus, @oType)",
                Program.Connection);

            cmd.Parameters.AddWithValue("@id", $"ORD{next.ToString().PadLeft(3, '0')}");
            cmd.Parameters.AddWithValue("@custId", detail.CustomerID);
            cmd.Parameters.AddWithValue("@quoId", detail.QuotationID);
            cmd.Parameters.AddWithValue("@oDate", detail.OrderDate);
            cmd.Parameters.AddWithValue("@deadline", detail.Deadline);
            cmd.Parameters.AddWithValue("@status", detail.Status);
            cmd.Parameters.AddWithValue("@deposit", detail.DepositPaid);
            cmd.Parameters.AddWithValue("@balance", detail.BalanceDue);
            cmd.Parameters.AddWithValue("@total", detail.TotalAmount);
            cmd.Parameters.AddWithValue("@payStatus", detail.PaymentStatus);
            cmd.Parameters.AddWithValue("@oType", detail.OrderType);

            try { cmd.ExecuteNonQuery(); LoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding order:\n{ex.Message}",
                                "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*──────────────────────────────────────────────────────────
         *  EDIT ORDER
         * ─────────────────────────────────────────────────────────*/
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = dataGridView1.SelectedRows[0];

            string id = r.Cells["CustomerOrderID"].Value.ToString();
            string quo = r.Cells["QuotationID"].Value.ToString();
            string custName = r.Cells["CustomerName"].Value.ToString();

            DateTime oDate = Convert.ToDateTime(r.Cells["OrderDate"].Value);
            DateTime dlDate = Convert.ToDateTime(r.Cells["Deadline"].Value);
            string status = r.Cells["Status"].Value.ToString();
            decimal deposit = Convert.ToDecimal(r.Cells["DepositPaid"].Value);
            decimal balance = Convert.ToDecimal(r.Cells["BalanceDue"].Value);
            decimal total = r.Cells["TotalAmount"].Value == DBNull.Value ? 0
                               : Convert.ToDecimal(r.Cells["TotalAmount"].Value);
            string payStat = r.Cells["PaymentStatus"].Value.ToString();
            string oType = r.Cells["OrderType"].Value.ToString();

            using var detail = new OrderDetailForm
            {
                Text = "Edit Order"
            };
            detail.SetFields(id, custName, quo, oDate, dlDate,
                             status, deposit, balance, total, payStat, oType);

            if (detail.ShowDialog() != DialogResult.OK) return;

            using var cmd = new MySqlCommand(@"
                UPDATE CustomerOrder SET
                    CustomerID     = @custId,
                    QuotationID    = @quoId,
                    OrderDate      = @oDate,
                    Deadline       = @deadline,
                    Status         = @status,
                    DepositPaid    = @deposit,
                    BalanceDue     = @balance,
                    TotalAmount    = @total,
                    PaymentStatus  = @payStatus,
                    OrderType      = @oType
                WHERE CustomerOrderID = @id", Program.Connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@custId", detail.CustomerID);
            cmd.Parameters.AddWithValue("@quoId", detail.QuotationID);
            cmd.Parameters.AddWithValue("@oDate", detail.OrderDate);
            cmd.Parameters.AddWithValue("@deadline", detail.Deadline);
            cmd.Parameters.AddWithValue("@status", detail.Status);
            cmd.Parameters.AddWithValue("@deposit", detail.DepositPaid);
            cmd.Parameters.AddWithValue("@balance", detail.BalanceDue);
            cmd.Parameters.AddWithValue("@total", detail.TotalAmount);
            cmd.Parameters.AddWithValue("@payStatus", detail.PaymentStatus);
            cmd.Parameters.AddWithValue("@oType", detail.OrderType);

            try { cmd.ExecuteNonQuery(); LoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order:\n{ex.Message}",
                                "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
