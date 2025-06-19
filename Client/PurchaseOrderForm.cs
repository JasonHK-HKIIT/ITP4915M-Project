using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class PurchaseOrderForm : Form
    {
        public PurchaseOrderForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;    // Add
            button2.Click += ButtonEdit_Click;   // Edit
            textBox1.KeyUp += textBox1_KeyUp;    // Search on Enter
            LoadData();
        }

        private void LoadData()
        {
            string filter = textBox1.Text.Trim();
            MySqlCommand cmd;

            string baseQuery = @"
        SELECT PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, Status, POStatus 
        FROM PurchaseOrder";

            if (string.IsNullOrEmpty(filter))
            {
                cmd = new MySqlCommand(baseQuery, Program.Connection);
            }
            else
            {
                // Filter across all columns, including date fields as string
                baseQuery += @"
            WHERE PurchaseOrderID LIKE @f
               OR SupplierID LIKE @f
               OR CAST(OrderDate AS CHAR) LIKE @f
               OR CAST(ExpectedDeliveryDate AS CHAR) LIKE @f
               OR Status LIKE @f
               OR POStatus LIKE @f";

                cmd = new MySqlCommand(baseQuery, Program.Connection);
                cmd.Parameters.AddWithValue("@f", $"%{filter}%");
            }

            var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Format date columns to match DB format (yyyy-MM-dd)
                if (dataGridView1.Columns.Contains("OrderDate"))
                    dataGridView1.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                if (dataGridView1.Columns.Contains("ExpectedDeliveryDate"))
                    dataGridView1.Columns["ExpectedDeliveryDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading purchase orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new PurchaseOrderDetailForm())
            {
                detail.Text = "Add Purchase Order";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    var lastIdCommand = new MySqlCommand("SELECT PurchaseOrderID FROM PurchaseOrder ORDER BY PurchaseOrderID DESC LIMIT 1", Program.Connection);
                    var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "PUR000";
                    var nextId = int.Parse(lastIdString.Substring(3)) + 1;

                    var cmd = new MySqlCommand(
                        @"INSERT INTO PurchaseOrder 
                            (PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, Status, POStatus) 
                          VALUES 
                            (@id, @sid, @odate, @ddate, @status, @postatus)",
                        Program.Connection
                    );
                    cmd.Parameters.AddWithValue("@id", $"PUR{nextId.ToString().PadLeft(3, '0')}");
                    cmd.Parameters.AddWithValue("@sid", detail.SupplierID);
                    cmd.Parameters.AddWithValue("@odate", detail.OrderDate);
                    cmd.Parameters.AddWithValue("@ddate", detail.DeliveryDate);
                    cmd.Parameters.AddWithValue("@status", detail.Status);
                    cmd.Parameters.AddWithValue("@postatus", detail.POStatus);

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
                MessageBox.Show("Please select a purchase order to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select only one purchase order to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string id = row.Cells["PurchaseOrderID"].Value.ToString();
            string sid = row.Cells["SupplierID"].Value.ToString();
            DateTime odate = Convert.ToDateTime(row.Cells["OrderDate"].Value);
            DateTime ddate = Convert.ToDateTime(row.Cells["ExpectedDeliveryDate"].Value);
            string status = row.Cells["Status"].Value.ToString();
            string postatus = row.Cells["POStatus"].Value.ToString();

            using (var detail = new PurchaseOrderDetailForm())
            {
                detail.Text = "Edit Purchase Order";
                detail.SetFields(id, sid, odate, ddate, status, postatus);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    var cmd = new MySqlCommand(
                        @"UPDATE PurchaseOrder 
                  SET SupplierID=@sid, OrderDate=@odate, ExpectedDeliveryDate=@ddate, Status=@status, POStatus=@postatus 
                  WHERE PurchaseOrderID=@id",
                        Program.Connection
                    );
                    cmd.Parameters.AddWithValue("@sid", detail.SupplierID);
                    cmd.Parameters.AddWithValue("@odate", detail.OrderDate);
                    cmd.Parameters.AddWithValue("@ddate", detail.DeliveryDate);
                    cmd.Parameters.AddWithValue("@status", detail.Status);
                    cmd.Parameters.AddWithValue("@postatus", detail.POStatus);
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


        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
