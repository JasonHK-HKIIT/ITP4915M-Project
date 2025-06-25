using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Client.PurchaseOrderDetailForm;

namespace Client
{
    public partial class PurchaseOrderForm : Form
    {
        public PurchaseOrderForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Text = "PurchaseOrderForm";
            this.Icon = Properties.Resources.Icon_Form;

            this.Load += PurchaseOrderForm_Load;
        }

        private void LoadData()
        {
            string filter = textBox1.Text.Trim();
            MySqlCommand cmd;
            string baseQuery = @"SELECT PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, Status, POStatus FROM PurchaseOrder";

            if (string.IsNullOrEmpty(filter))
            {
                cmd = new MySqlCommand(baseQuery, Program.Connection);
            }
            else
            {
                baseQuery += @" WHERE PurchaseOrderID LIKE @f OR SupplierID LIKE @f OR CAST(OrderDate AS CHAR) LIKE @f OR CAST(ExpectedDeliveryDate AS CHAR) LIKE @f OR Status LIKE @f OR POStatus LIKE @f";
                cmd = new MySqlCommand(baseQuery, Program.Connection);
                cmd.Parameters.AddWithValue("@f", $"%{filter}%");
            }

            var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();

            try
            {
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

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
                    // Generate new PurchaseOrderID
                    var lastIdCommand = new MySqlCommand("SELECT PurchaseOrderID FROM PurchaseOrder ORDER BY PurchaseOrderID DESC LIMIT 1", Program.Connection);
                    var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "PUR000";
                    var nextId = int.Parse(lastIdString.Substring(3)) + 1;
                    string newId = $"PUR{nextId.ToString().PadLeft(3, '0')}";

                    var cmd = new MySqlCommand("INSERT INTO PurchaseOrder (PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, Status, POStatus) VALUES (@id, @sid, @odate, @ddate, @status, @postatus)", Program.Connection);
                    cmd.Parameters.AddWithValue("@id", newId);
                    cmd.Parameters.AddWithValue("@sid", detail.SupplierID);
                    cmd.Parameters.AddWithValue("@odate", detail.OrderDate);
                    cmd.Parameters.AddWithValue("@ddate", detail.DeliveryDate);
                    cmd.Parameters.AddWithValue("@status", detail.Status);
                    cmd.Parameters.AddWithValue("@postatus", detail.POStatus);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        foreach (var line in detail.GetLineItems())
                        {
                            var lineCmd = new MySqlCommand("INSERT INTO PurchaseOrderLine (PurchaseOrderID, MaterialID, Quantity, ReceivedQuantity) VALUES (@poid, @mid, @qty, @rcvqty)", Program.Connection);
                            lineCmd.Parameters.AddWithValue("@poid", newId);
                            lineCmd.Parameters.AddWithValue("@mid", line.MaterialID);
                            lineCmd.Parameters.AddWithValue("@qty", line.Quantity);
                            lineCmd.Parameters.AddWithValue("@rcvqty", line.ReceivedQuantity);
                            lineCmd.ExecuteNonQuery();
                        }

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
            if (dataGridView1.CurrentRow == null) return;

            // Get header values
            string poId = dataGridView1.CurrentRow.Cells["PurchaseOrderID"].Value.ToString();
            string supplierId = dataGridView1.CurrentRow.Cells["SupplierID"].Value.ToString();
            DateTime orderDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["OrderDate"].Value);
            DateTime deliveryDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["ExpectedDeliveryDate"].Value);
            string status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
            string poStatus = dataGridView1.CurrentRow.Cells["POStatus"].Value.ToString();

            // Load lines
            List<PurchaseOrderDetailForm.PurchaseOrderLine> poLines = new();
            var cmd = new MySqlCommand(@"
        SELECT pol.MaterialID, m.MaterialName, m.Description, pol.Quantity, pol.ReceivedQuantity
        FROM PurchaseOrderLine pol
        JOIN Material m ON pol.MaterialID = m.MaterialID
        WHERE pol.PurchaseOrderID = @poid", Program.Connection);
            cmd.Parameters.AddWithValue("@poid", poId);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    poLines.Add(new PurchaseOrderDetailForm.PurchaseOrderLine
                    {
                        MaterialID = reader["MaterialID"]?.ToString(),
                        MaterialName = reader["MaterialName"]?.ToString(),
                        Description = reader["Description"]?.ToString(),
                        Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0,
                        ReceivedQuantity = reader["ReceivedQuantity"] != DBNull.Value ? Convert.ToInt32(reader["ReceivedQuantity"]) : 0
                    });
                }
            }

           
            using (var detail = new PurchaseOrderDetailForm())
            {
                detail.Text = "Edit Purchase Order";
                detail.SetFields(poId, supplierId, orderDate, deliveryDate, status, poStatus, poLines);

                if (detail.ShowDialog() == DialogResult.OK)
                {
                    // Update header (if needed)
                    var updateCmd = new MySqlCommand(
                        "UPDATE PurchaseOrder SET SupplierID=@sid, OrderDate=@odate, ExpectedDeliveryDate=@ddate, Status=@status, POStatus=@postatus WHERE PurchaseOrderID=@id",
                        Program.Connection);
                    updateCmd.Parameters.AddWithValue("@id", poId);
                    updateCmd.Parameters.AddWithValue("@sid", detail.SupplierID);
                    updateCmd.Parameters.AddWithValue("@odate", detail.OrderDate);
                    updateCmd.Parameters.AddWithValue("@ddate", detail.DeliveryDate);
                    updateCmd.Parameters.AddWithValue("@status", detail.Status);
                    updateCmd.Parameters.AddWithValue("@postatus", detail.POStatus);
                    updateCmd.ExecuteNonQuery();

                    // Delete old lines
                    var deleteCmd = new MySqlCommand("DELETE FROM PurchaseOrderLine WHERE PurchaseOrderID=@id", Program.Connection);
                    deleteCmd.Parameters.AddWithValue("@id", poId);
                    deleteCmd.ExecuteNonQuery();

                    // Insert new/edited lines
                    foreach (var line in detail.GetLineItems())
                    {
                        var lineCmd = new MySqlCommand(
                            "INSERT INTO PurchaseOrderLine (PurchaseOrderID, MaterialID, Quantity, ReceivedQuantity) VALUES (@poid, @mid, @qty, @rcvqty)",
                            Program.Connection);
                        lineCmd.Parameters.AddWithValue("@poid", poId);
                        lineCmd.Parameters.AddWithValue("@mid", line.MaterialID);
                        lineCmd.Parameters.AddWithValue("@qty", line.Quantity);
                        lineCmd.Parameters.AddWithValue("@rcvqty", line.ReceivedQuantity);
                        lineCmd.ExecuteNonQuery();
                    }

                    LoadData();
                }
            }
        }


        private void ButtonViewPOLines_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one purchase order to view.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string poId = dataGridView1.SelectedRows[0].Cells["PurchaseOrderID"].Value.ToString();
            var linesForm = new ViewPurchaseOrderLinesForm(poId);
            linesForm.ShowDialog();
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
