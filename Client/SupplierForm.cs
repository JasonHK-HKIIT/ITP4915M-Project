using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();

            // ─── Form appearance ───
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Text = "Supplier Form";
            this.Icon = Properties.Resources.Icon_Form;

            // ─── Font styling ───
            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);

            // ─── UI styling ───
            StyleButtons();
            StyleGrid();

            // ─── Event handlers ───
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            button3.Click += ButtonDelete_Click;
            button4.Click += ButtonToggleActive_Click;
            textBox1.KeyUp += textBox1_KeyUp;

            LoadData();
        }

        // ───── Styling Methods ─────
        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Font = font;
                if (ctrl.HasChildren)
                    ApplyFont(ctrl, font);
            }
        }

        private void StyleButtons()
        {
            ButtonStyle(button1, "Add Supplier", Color.MediumSeaGreen);
            ButtonStyle(button2, "Edit Supplier", Color.CornflowerBlue);
            ButtonStyle(button3, "Delete Supplier", Color.IndianRed);
            ButtonStyle(button4, "Activate / Deactivate", Color.DarkOrange);
        }

        private void ButtonStyle(Button button, string text, Color backColor)
        {
            button.Text = text;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private void StyleGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = this.Font;
        }

        // ───── Load & Search ─────
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            string baseSql = @"
                SELECT SupplierID, SupplierName, ContactPerson, PhoneNumber, Email, Address, Country, Status, CreatedAt 
                FROM Supplier";

            MySqlCommand command;
            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(baseSql, Program.Connection);
            }
            else
            {
                baseSql += @"
                    WHERE SupplierID LIKE @q
                       OR SupplierName LIKE @q
                       OR ContactPerson LIKE @q
                       OR PhoneNumber LIKE @q
                       OR Email LIKE @q
                       OR Address LIKE @q
                       OR Country LIKE @q
                       OR Status LIKE @q
                       OR CAST(CreatedAt AS CHAR) LIKE @q";
                command = new MySqlCommand(baseSql, Program.Connection);
                command.Parameters.AddWithValue("@q", $"%{query}%");
            }

            var adapter = new MySqlDataAdapter(command);
            var table = new DataTable();

            try
            {
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                if (dataGridView1.Columns.Contains("CreatedAt"))
                    dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        // ───── Add Supplier ─────
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new SupplierDetailForm { Text = "Add Supplier" })
            {
                if (detail.ShowDialog() != DialogResult.OK) return;

                var lastIdCmd = new MySqlCommand("SELECT SupplierID FROM Supplier ORDER BY SupplierID DESC LIMIT 1", Program.Connection);
                var lastId = lastIdCmd.ExecuteScalar() as string ?? "SUP000";
                var nextId = int.Parse(lastId.Substring(3)) + 1;

                using var cmd = new MySqlCommand(@"
                    INSERT INTO Supplier 
                    (SupplierID, SupplierName, ContactPerson, PhoneNumber, Email, Address, Country, Status) 
                    VALUES 
                    (@id, @name, @contact, @phone, @email, @address, @country, @status)", Program.Connection);

                cmd.Parameters.AddWithValue("@id", $"SUP{nextId.ToString().PadLeft(3, '0')}");
                cmd.Parameters.AddWithValue("@name", detail.SupplierName);
                cmd.Parameters.AddWithValue("@contact", detail.ContactPerson);
                cmd.Parameters.AddWithValue("@phone", detail.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", detail.Email);
                cmd.Parameters.AddWithValue("@address", detail.Address);
                cmd.Parameters.AddWithValue("@country", detail.Country);
                cmd.Parameters.AddWithValue("@status", detail.Status);

                try { cmd.ExecuteNonQuery(); LoadData(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ───── Edit Supplier ─────
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string originalId = row.Cells["SupplierID"].Value.ToString();

            using (var detail = new SupplierDetailForm { Text = "Edit Supplier" })
            {
                detail.SetFields(
                    row.Cells["SupplierID"].Value?.ToString(),
                    row.Cells["SupplierName"].Value?.ToString(),
                    row.Cells["ContactPerson"].Value?.ToString(),
                    row.Cells["PhoneNumber"].Value?.ToString(),
                    row.Cells["Email"].Value?.ToString(),
                    row.Cells["Address"].Value?.ToString(),
                    row.Cells["Country"].Value?.ToString(),
                    row.Cells["Status"].Value?.ToString()
                );

                if (detail.ShowDialog() != DialogResult.OK) return;

                using var cmd = new MySqlCommand(@"
                    UPDATE Supplier SET 
                        SupplierID=@id, 
                        SupplierName=@name, 
                        ContactPerson=@contact, 
                        PhoneNumber=@phone, 
                        Email=@email, 
                        Address=@address, 
                        Country=@country,
                        Status=@status
                    WHERE SupplierID=@originalId", Program.Connection);

                cmd.Parameters.AddWithValue("@id", detail.SupplierID);
                cmd.Parameters.AddWithValue("@name", detail.SupplierName);
                cmd.Parameters.AddWithValue("@contact", detail.ContactPerson);
                cmd.Parameters.AddWithValue("@phone", detail.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", detail.Email);
                cmd.Parameters.AddWithValue("@address", detail.Address);
                cmd.Parameters.AddWithValue("@country", detail.Country);
                cmd.Parameters.AddWithValue("@status", detail.Status);
                cmd.Parameters.AddWithValue("@originalId", originalId);

                try { cmd.ExecuteNonQuery(); LoadData(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ───── Activate/Deactivate Supplier ─────
        private void ButtonToggleActive_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to activate/deactivate.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string supplierId = row.Cells["SupplierID"].Value.ToString();
            string currentStatus = row.Cells["Status"].Value.ToString();
            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";

            using var cmd = new MySqlCommand("UPDATE Supplier SET Status=@status WHERE SupplierID=@id", Program.Connection);
            cmd.Parameters.AddWithValue("@status", newStatus);
            cmd.Parameters.AddWithValue("@id", supplierId);

            try { cmd.ExecuteNonQuery(); LoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ───── Delete Supplier ─────
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string supplierId = dataGridView1.SelectedRows[0].Cells["SupplierID"].Value.ToString();
            var confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using var cmd = new MySqlCommand("DELETE FROM Supplier WHERE SupplierID=@id", Program.Connection);
            cmd.Parameters.AddWithValue("@id", supplierId);

            try { cmd.ExecuteNonQuery(); LoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
