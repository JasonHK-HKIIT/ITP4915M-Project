using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class DesignRequestForm : Form
    {
        public DesignRequestForm()
        {
            InitializeComponent();

            // Restore default Windows form border
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;  // enable maximize if needed
            this.MinimizeBox = true;

            // Set form title (will appear in top-left)
            this.Text = "Design Request Form";
            this.Icon = Properties.Resources.Icon_Form;

            // Set UI font
            Font font;
            try { font = new Font("Helvetica", 10); }
            catch { font = new Font("Segoe UI", 10); }
            ApplyFont(this, font);

            // Apply UI styles
            StyleButtons();
            StyleGrid();
        }

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
            ButtonStyle(AddButton, "Add Request", Color.MediumSeaGreen);
            ButtonStyle(EditButton, "Edit Selected", Color.CornflowerBlue);
            ButtonStyle(BtnCancelSelected, "Delete Selected", Color.IndianRed);
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
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        }

        private void LoadData()
        {
            string query = SearchField.Text.Trim();
            string baseQuery = @"
                SELECT 
                    dr.DesignRequestID,
                    c.CustomerName,
                    dr.RequestDate,
                    dr.Specifications,
                    dr.Status,
                    dr.ConsultantFee,
                    dr.ApprovalDate,
                    u1.Name AS AssignedManagerName,
                    u2.Name AS ApprovedBy
                FROM ProductDesignRequest dr
                LEFT JOIN Customer c ON dr.CustomerID = c.CustomerID
                LEFT JOIN User u1 ON dr.UserID = u1.UserID
                LEFT JOIN User u2 ON dr.ApprovedBy = u2.UserID";

            string filteredQuery = baseQuery + " WHERE dr.DesignRequestID LIKE @id OR c.CustomerName LIKE @id";
            var cmd = new MySqlCommand(string.IsNullOrEmpty(query) ? baseQuery : filteredQuery, Program.Connection);

            if (!string.IsNullOrEmpty(query))
                cmd.Parameters.AddWithValue("@id", $"%{query}%");

            var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void DesignRequestForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SearchField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var detail = new DesignRequestDetailForm())
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a request to edit.");
                return;
            }

            var id = dataGridView1.SelectedRows[0].Cells["DesignRequestID"].Value.ToString();
            using (var detail = new DesignRequestDetailForm(id))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnCancelSelected_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a request to cancel.");
                return;
            }

            var id = dataGridView1.SelectedRows[0].Cells["DesignRequestID"].Value.ToString();
            var currentStatus = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();

            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This request is already cancelled.");
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to cancel DesignRequest {id}?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            var cmd = new MySqlCommand("UPDATE ProductDesignRequest SET Status='Cancelled' WHERE DesignRequestID=@id", Program.Connection);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Design request cancelled.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling request: " + ex.Message);
            }
        }
    }
}
