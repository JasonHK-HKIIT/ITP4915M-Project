using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();

            // Wire up button click events
            button3.Click += ButtonAdd_Click;    // Add Order
            button2.Click += ButtonEdit_Click;   // Edit Order
            textBox1.KeyUp += textBox1_KeyUp;    // Search on Enter key

            LoadData(); // Initial load
        }

        /// <summary>
        /// Load customer orders from the database.
        /// Supports search by OrderID, CustomerName, QuotationID, Status, or PaymentStatus.
        /// </summary>
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            MySqlCommand command;

            // Base SQL query with JOIN to include CustomerName
            string baseQuery = @"
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

            // If search term exists, filter by multiple fields
            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(baseQuery, Program.Connection);
            }
            else
            {
                baseQuery += @"
                    WHERE 
                        o.CustomerOrderID LIKE @q OR 
                        c.CustomerName LIKE @q OR 
                        o.QuotationID LIKE @q OR 
                        o.Status LIKE @q OR 
                        o.PaymentStatus LIKE @q";

                command = new MySqlCommand(baseQuery, Program.Connection);
                command.Parameters.AddWithValue("@q", $"%{query}%");
            }

            var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();

            try
            {
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Trigger search when Enter is pressed in search box.
        /// </summary>
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        /// <summary>
        /// Handle adding a new customer order.
        /// Opens the OrderDetailForm and inserts into the database on success.
        /// </summary>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new OrderDetailForm())
            {
                detail.Text = "Add Order";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    var lastIdCommand = new MySqlCommand("SELECT CustomerOrderID FROM CustomerOrder ORDER BY CustomerOrderID DESC LIMIT 1", Program.Connection);
                    var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "ORD000";
                    var nextId = int.Parse(lastIdString.Substring(3)) + 1;

                    // Prepare insert command
                    using (var command = new MySqlCommand(
                        @"INSERT INTO CustomerOrder 
                          (CustomerOrderID, CustomerID, QuotationID, OrderDate, Deadline, Status, DepositPaid, BalanceDue, TotalAmount, PaymentStatus, OrderType)
                          VALUES
                          (@id, @customerId, @quotationId, @orderDate, @deadline, @status, @deposit, @balance, @total, @paymentStatus, @orderType)",
                        Program.Connection))
                    {
                        // Bind form data to SQL parameters
                        command.Parameters.AddWithValue("@id", $"ORD{nextId.ToString().PadLeft(3, '0')}");
                        command.Parameters.AddWithValue("@customerId", detail.CustomerID);
                        command.Parameters.AddWithValue("@quotationId", detail.QuotationID);
                        command.Parameters.AddWithValue("@orderDate", detail.OrderDate);
                        command.Parameters.AddWithValue("@deadline", detail.Deadline);
                        command.Parameters.AddWithValue("@status", detail.Status);
                        command.Parameters.AddWithValue("@deposit", detail.DepositPaid);
                        command.Parameters.AddWithValue("@balance", detail.BalanceDue);
                        command.Parameters.AddWithValue("@total", detail.TotalAmount);
                        command.Parameters.AddWithValue("@paymentStatus", detail.PaymentStatus);
                        command.Parameters.AddWithValue("@orderType", detail.OrderType);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Handle editing an existing customer order.
        /// Pre-fills OrderDetailForm with selected row data and updates database if confirmed.
        /// </summary>
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];

            // Extract data from selected row
            string orderId = row.Cells["CustomerOrderID"].Value.ToString();
            string customerName = row.Cells["CustomerName"].Value.ToString();
            string quotationId = row.Cells["QuotationID"].Value.ToString();
            DateTime orderDate = Convert.ToDateTime(row.Cells["OrderDate"].Value);
            DateTime deadline = Convert.ToDateTime(row.Cells["Deadline"].Value);
            string status = row.Cells["Status"].Value.ToString();
            decimal deposit = Convert.ToDecimal(row.Cells["DepositPaid"].Value);
            decimal balance = Convert.ToDecimal(row.Cells["BalanceDue"].Value);
            decimal total = row.Cells["TotalAmount"].Value == DBNull.Value ? 0 : Convert.ToDecimal(row.Cells["TotalAmount"].Value);
            string paymentStatus = row.Cells["PaymentStatus"].Value.ToString();
            string orderType = row.Cells["OrderType"].Value.ToString();

            using (var detail = new OrderDetailForm())
            {
                detail.Text = "Edit Order";
                detail.SetFields(orderId, customerName, quotationId, orderDate, deadline, status, deposit, balance, total, paymentStatus, orderType);

                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"UPDATE CustomerOrder SET 
                              CustomerID=@customerId,
                              QuotationID=@quotationId,
                              OrderDate=@orderDate,
                              Deadline=@deadline,
                              Status=@status,
                              DepositPaid=@deposit,
                              BalanceDue=@balance,
                              TotalAmount=@total,
                              PaymentStatus=@paymentStatus,
                              OrderType=@orderType
                          WHERE CustomerOrderID=@id",
                        Program.Connection))
                    {
                        // Bind form values to update
                        command.Parameters.AddWithValue("@id", orderId);
                        command.Parameters.AddWithValue("@customerId", detail.CustomerID);
                        command.Parameters.AddWithValue("@quotationId", detail.QuotationID);
                        command.Parameters.AddWithValue("@orderDate", detail.OrderDate);
                        command.Parameters.AddWithValue("@deadline", detail.Deadline);
                        command.Parameters.AddWithValue("@status", detail.Status);
                        command.Parameters.AddWithValue("@deposit", detail.DepositPaid);
                        command.Parameters.AddWithValue("@balance", detail.BalanceDue);
                        command.Parameters.AddWithValue("@total", detail.TotalAmount);
                        command.Parameters.AddWithValue("@paymentStatus", detail.PaymentStatus);
                        command.Parameters.AddWithValue("@orderType", detail.OrderType);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadData();
                }
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Optional: logic when form loads (already covered by constructor)
        }
    }
}
