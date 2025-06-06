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

            button3.Click += ButtonAdd_Click;    // Add Order
            button2.Click += ButtonEdit_Click;   // Edit Order
            textBox1.KeyUp += textBox1_KeyUp;    // Search (OrderID or Customer Name)

            LoadData();
        }

        // Load orders, optionally filtered by ID or Customer name
        private void LoadData()
        {
            string query = textBox1.Text.Trim();
            MySqlCommand command;

            if (string.IsNullOrEmpty(query))
            {
                command = new MySqlCommand(
                    @"SELECT o.CustomerOrderID, c.CustomerName, o.QuotationID, o.OrderDate, o.Deadline, 
                     o.Status, o.DepositPaid, o.BalanceDue, o.TotalAmount, o.PaymentStatus, o.OrderType
              FROM CustomerOrder o
              LEFT JOIN Customer c ON o.CustomerID = c.CustomerID",
                    Program.Connection
                );
            }
            else
            {
                command = new MySqlCommand(
                    @"SELECT o.CustomerOrderID, c.CustomerName, o.QuotationID, o.OrderDate, o.Deadline, 
                     o.Status, o.DepositPaid, o.BalanceDue, o.TotalAmount, o.PaymentStatus, o.OrderType
              FROM CustomerOrder o
              LEFT JOIN Customer c ON o.CustomerID = c.CustomerID
              WHERE o.CustomerOrderID LIKE @q OR c.CustomerName LIKE @q",
                    Program.Connection
                );
                command.Parameters.AddWithValue("@q", "%" + query + "%");
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


        // Search on Enter key
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        // Add new order
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new OrderDetailForm())
            {
                detail.Text = "Add Order";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    using (var command = new MySqlCommand(
                        @"INSERT INTO CustomerOrder 
                            (CustomerOrderID, CustomerID, QuotationID, OrderDate, Deadline, Status, DepositPaid, BalanceDue, TotalAmount, PaymentStatus, OrderType)
                          VALUES
                            (@id, @customerId, @quotationId, @orderDate, @deadline, @status, @deposit, @balance, @total, @paymentStatus, @orderType)",
                        Program.Connection))
                    {
                        command.Parameters.AddWithValue("@id", detail.OrderID);
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

        // Edit existing order
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridView1.SelectedRows[0];

            // Map row fields to the detail form
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

        }
    }
}
