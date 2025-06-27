using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class ServiceCaseForm : Form
    {
        public ServiceCaseForm()
        {
            InitializeComponent();

            // ─── Form chrome & icon ─────────────────────────────
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Text = "ServiceCaseForm";
            this.Icon = Properties.Resources.Icon_Form;

            // ─── Font cascade (Helvetica → Segoe UI fallback) ───
            Font uiFont;
            try { uiFont = new Font("Helvetica", 10); }
            catch { uiFont = new Font("Segoe UI", 10); }
            ApplyFont(this, uiFont);

            // ─── Style buttons & grid ───────────────────────────
            StyleButtons();
            StyleGrid();

            // ─── Wire events ────────────────────────────────────
            button1.Click += ButtonAdd_Click;     // Add
            button2.Click += ButtonEdit_Click;    // Edit
            button3.Click += ButtonDelete_Click;  // Delete
            textBox1.KeyUp += TextBoxSearch_KeyUp;

            LoadData(); // initial load
        }

        /*────────────────────────────────────────────────────────
         * UI-STYLE HELPERS (copied from CustomerForm.cs)
         *────────────────────────────────────────────────────────*/
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
            if (button1 != null) ButtonStyle(button1, "Add Case", Color.MediumSeaGreen); // ✅
            if (button2 != null) ButtonStyle(button2, "Edit Case", Color.CornflowerBlue); // ✏️
            if (button3 != null) ButtonStyle(button3, "Delete Case", Color.IndianRed);      // ❌
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

        /*────────────────────────────────────────────────────────
         * SEARCH & LOAD
         *────────────────────────────────────────────────────────*/
        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) LoadData(); }

        private void LoadData()
        {
            string q = textBox1.Text.Trim();

            string sql = @"
                SELECT 
                    csc.CaseID,
                    c.CustomerName              AS Customer,
                    csc.CustomerOrderID         AS `Order`,
                    csc.CaseDate,
                    csc.Description,
                    csc.Status,
                    csc.Resolution,
                    csc.CaseType,
                    u.Name                       AS AssignedTo
                FROM CustomerServiceCase csc
                LEFT JOIN Customer c ON csc.CustomerID = c.CustomerID
                LEFT JOIN User     u ON csc.AssignedStaffID = u.UserID";

            using var cmd = new MySqlCommand(sql, Program.Connection);

            if (!string.IsNullOrEmpty(q))
            {
                sql += @"
                    WHERE csc.CaseID          LIKE @q
                       OR c.CustomerName      LIKE @q
                       OR csc.CustomerOrderID LIKE @q";

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
                MessageBox.Show($"Error loading service cases:\n{ex.Message}",
                                "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*────────────────────────────────────────────────────────
         * ADD
         *────────────────────────────────────────────────────────*/
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using var detail = new ServiceCaseDetailForm { Text = "Add Service Case" };
            if (detail.ShowDialog() != DialogResult.OK) return;

            var lastCmd = new MySqlCommand(
                "SELECT CaseID FROM CustomerServiceCase ORDER BY CaseID DESC LIMIT 1",
                Program.Connection);
            var last = lastCmd.ExecuteScalar() as string ?? "CASE000";
            int next = int.Parse(last.Substring(4)) + 1;

            using var cmd = new MySqlCommand(@"
                INSERT INTO CustomerServiceCase
                    (CaseID, CustomerID, CustomerOrderID, CaseDate, Description,
                     Status, Resolution, CaseType, AssignedStaffID)
                VALUES
                    (@id, @custId, @orderId, @date, @desc,
                     @status, @resolution, @type, @staffId)", Program.Connection);

            cmd.Parameters.AddWithValue("@id", $"CASE{next.ToString().PadLeft(3, '0')}");
            cmd.Parameters.AddWithValue("@custId", detail.CustomerID);
            cmd.Parameters.AddWithValue("@orderId", string.IsNullOrWhiteSpace(detail.CustomerOrderID)
                                                    ? (object)DBNull.Value : detail.CustomerOrderID);
            cmd.Parameters.AddWithValue("@date", detail.CaseDate);
            cmd.Parameters.AddWithValue("@desc", detail.Description);
            cmd.Parameters.AddWithValue("@status", detail.Status);
            cmd.Parameters.AddWithValue("@resolution",
                                         string.IsNullOrWhiteSpace(detail.Resolution)
                                         ? (object)DBNull.Value : detail.Resolution);
            cmd.Parameters.AddWithValue("@type", detail.CaseType);
            cmd.Parameters.AddWithValue("@staffId", string.IsNullOrWhiteSpace(detail.AssignedStaffID)
                                                    ? (object)DBNull.Value : detail.AssignedStaffID);

            try { cmd.ExecuteNonQuery(); LoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding service case:\n{ex.Message}",
                                "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*────────────────────────────────────────────────────────
         * EDIT
         *────────────────────────────────────────────────────────*/
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service case to edit.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string caseId = dataGridView1.SelectedRows[0].Cells["CaseID"].Value.ToString();

            // Fetch record for full detail (safer than grid cells for NULLs)
            string custId = "", orderId = "", desc = "", status = "",
                   resolution = "", type = "", staffId = "";
            DateTime caseDate = DateTime.Now;

            using (var fetch = new MySqlCommand(
                "SELECT * FROM CustomerServiceCase WHERE CaseID = @id", Program.Connection))
            {
                fetch.Parameters.AddWithValue("@id", caseId);
                using var rdr = fetch.ExecuteReader();
                if (rdr.Read())
                {
                    custId = rdr["CustomerID"].ToString();
                    orderId = rdr["CustomerOrderID"] == DBNull.Value ? "" : rdr["CustomerOrderID"].ToString();
                    caseDate = rdr["CaseDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rdr["CaseDate"]);
                    desc = rdr["Description"].ToString();
                    status = rdr.GetString("Status");
                    resolution = rdr["Resolution"] == DBNull.Value ? "" : rdr["Resolution"].ToString();
                    type = rdr.GetString("CaseType");
                    staffId = rdr["AssignedStaffID"].ToString();
                }
            }

            using var detail = new ServiceCaseDetailForm
            {
                Text = "Edit Service Case"
            };
            detail.SetFields(caseId, custId, orderId, caseDate,
                             desc, status, resolution, type, staffId);

            if (detail.ShowDialog() != DialogResult.OK) return;

            using var cmd = new MySqlCommand(@"
                UPDATE CustomerServiceCase SET
                    CustomerID      = @custId,
                    CustomerOrderID = @orderId,
                    CaseDate        = @date,
                    Description     = @desc,
                    Status          = @status,
                    Resolution      = @resolution,
                    CaseType        = @type,
                    AssignedStaffID = @staffId
                WHERE CaseID = @id", Program.Connection);

            cmd.Parameters.AddWithValue("@id", caseId);
            cmd.Parameters.AddWithValue("@custId", detail.CustomerID);
            cmd.Parameters.AddWithValue("@orderId", string.IsNullOrWhiteSpace(detail.CustomerOrderID)
                                                    ? (object)DBNull.Value : detail.CustomerOrderID);
            cmd.Parameters.AddWithValue("@date", detail.CaseDate);
            cmd.Parameters.AddWithValue("@desc", detail.Description);
            cmd.Parameters.AddWithValue("@status", detail.Status);
            cmd.Parameters.AddWithValue("@resolution",
                                         string.IsNullOrWhiteSpace(detail.Resolution)
                                         ? (object)DBNull.Value : detail.Resolution);
            cmd.Parameters.AddWithValue("@type", detail.CaseType);
            cmd.Parameters.AddWithValue("@staffId", string.IsNullOrWhiteSpace(detail.AssignedStaffID)
                                                    ? (object)DBNull.Value : detail.AssignedStaffID);

            try { cmd.ExecuteNonQuery(); LoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating service case:\n{ex.Message}",
                                "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*────────────────────────────────────────────────────────
         * DELETE
         *────────────────────────────────────────────────────────*/
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service case to delete.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string caseId = dataGridView1.SelectedRows[0].Cells["CaseID"].Value.ToString();
            var ok = MessageBox.Show("Are you sure you want to delete this service case?",
                                     "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok != DialogResult.Yes) return;

            using var cmd = new MySqlCommand(
                "DELETE FROM CustomerServiceCase WHERE CaseID = @id", Program.Connection);
            cmd.Parameters.AddWithValue("@id", caseId);

            try { cmd.ExecuteNonQuery(); LoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting service case:\n{ex.Message}",
                                "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*────────────────────────────────────────────────────────
         * OPTIONAL FORM-LOAD HOOK
         *────────────────────────────────────────────────────────*/
        private void ServiceCaseForm_Load(object sender, EventArgs e) { }
    }
}
