using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class ProductionForm : Form
    {
        public ProductionForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;      // Add Production Order
            button2.Click += ButtonEdit_Click;     // Edit Selected
            button3.Click += ButtonDelete_Click;   // Delete Selected
            textBox1.KeyUp += textBox1_KeyUp;      // Search on Enter
            LoadData();
        }

        /// <summary>
        /// Loads production orders from DB, optionally filtered.
        /// </summary>
        private void LoadData()
        {
            string filter = textBox1.Text.Trim();
            MySqlCommand cmd;

            if (string.IsNullOrEmpty(filter))
            {
                cmd = new MySqlCommand(
                    "SELECT ProductionOrderID, CustomerOrderID, ProductID, Quantity, ScheduledDate, Status FROM ProductionOrder",
                    Program.Connection
                );
            }
            else
            {
                cmd = new MySqlCommand(
                    @"SELECT ProductionOrderID, CustomerOrderID, ProductID, Quantity, ScheduledDate, Status 
              FROM ProductionOrder 
              WHERE ProductionOrderID LIKE @f OR CustomerOrderID LIKE @f",
                    Program.Connection
                );
                cmd.Parameters.AddWithValue("@f", "%" + filter + "%");
            }

            var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading production orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new ProductionDetailForm())
            {
                detail.Text = "Add Production Order";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    var lastIdCommand = new MySqlCommand("SELECT ProductionOrderID FROM ProductionOrder ORDER BY ProductionOrderID DESC LIMIT 1", Program.Connection);
                    var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "PO000";
                    var nextId = int.Parse(lastIdString.Substring(2)) + 1;

                    var cmd = new MySqlCommand(
                        @"INSERT INTO ProductionOrder 
                            (ProductionOrderID, CustomerOrderID, ProductID, Quantity, ScheduledDate, Status) 
                          VALUES 
                            (@id, @co, @pid, @qty, @date, @status)",
                        Program.Connection
                    );
                    cmd.Parameters.AddWithValue("@id", $"PO{nextId.ToString().PadLeft(3, '0')}");
                    cmd.Parameters.AddWithValue("@co", detail.CustomerOrderID);
                    cmd.Parameters.AddWithValue("@pid", detail.ProductID);
                    cmd.Parameters.AddWithValue("@qty", detail.Quantity);
                    cmd.Parameters.AddWithValue("@date", detail.ScheduledDate);
                    cmd.Parameters.AddWithValue("@status", detail.Status);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insert failed: " + ex.Message, "Error");
                    }
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a production order to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string id = row.Cells["ProductionOrderID"].Value.ToString();
            string co = row.Cells["CustomerOrderID"].Value.ToString();
            string pid = row.Cells["ProductID"].Value.ToString();
            int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
            DateTime date = Convert.ToDateTime(row.Cells["ScheduledDate"].Value);
            string status = row.Cells["Status"].Value.ToString();

            using (var detail = new ProductionDetailForm())
            {
                detail.Text = "Edit Production Order";
                detail.SetFields(id, co, pid, qty, date, status);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    var cmd = new MySqlCommand(
                        @"UPDATE ProductionOrder 
                  SET CustomerOrderID=@co, ProductID=@pid, Quantity=@qty, ScheduledDate=@date, Status=@status 
                  WHERE ProductionOrderID=@id",
                        Program.Connection
                    );
                    cmd.Parameters.AddWithValue("@co", detail.CustomerOrderID);
                    cmd.Parameters.AddWithValue("@pid", detail.ProductID);
                    cmd.Parameters.AddWithValue("@qty", detail.Quantity);
                    cmd.Parameters.AddWithValue("@date", detail.ScheduledDate);
                    cmd.Parameters.AddWithValue("@status", detail.Status);
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update failed: " + ex.Message, "Error");
                    }
                }
            }
        }


        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];
            string id = row.Cells["ProductionOrderID"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete this production order?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var cmd = new MySqlCommand(
                    "DELETE FROM ProductionOrder WHERE ProductionOrderID=@id",
                    Program.Connection
                );
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message, "Error");
                }
            }
        }

        private void ProductionOrderForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
