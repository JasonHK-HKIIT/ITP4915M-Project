using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class OrderForm : Form
    {
        // Order Data Model
        public class Order
        {
            public string Customer { get; set; }
            public string Quotation { get; set; }
            public DateTime Dates { get; set; }
            public decimal Deposit { get; set; }
            public decimal Balance { get; set; }
            public decimal TotalAmount { get; set; }
            public string Status { get; set; }
            public string PaymentStatus { get; set; }
            public string OrderType { get; set; }
        }

        private List<Order> orders = new List<Order>();

        public OrderForm()
        {
            InitializeComponent();
            button3.Click += ButtonAdd_Click;   // "Add Order"
            button2.Click += ButtonEdit_Click;  // "Edit Selected"
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orders.Select(o => new
            {
                o.Customer,
                o.Quotation,
                Dates = o.Dates.ToShortDateString(),
                o.Deposit,
                o.Balance,
                o.TotalAmount,
                o.Status,
                o.PaymentStatus,
                o.OrderType
            }).ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new OrderDetailForm())
            {
                detail.Text = "Add Order";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    orders.Add(new Order
                    {
                        Customer = detail.Customer,
                        Quotation = detail.Quotation,
                        Dates = detail.OrderDate,
                        Deposit = detail.Deposit,
                        Balance = detail.Balance,
                        TotalAmount = detail.TotalAmount,
                        Status = detail.Status,
                        PaymentStatus = detail.PaymentStatus,
                        OrderType = detail.OrderType
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.");
                return;
            }
            int idx = dataGridView1.SelectedRows[0].Index;
            var o = orders[idx];
            using (var detail = new OrderDetailForm())
            {
                detail.Text = "Edit Order";
                detail.SetFields(
                    o.Customer,
                    o.Quotation,
                    o.Dates,
                    o.Deposit,
                    o.Balance,
                    o.TotalAmount,
                    o.Status,
                    o.PaymentStatus,
                    o.OrderType
                );
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    o.Customer = detail.Customer;
                    o.Quotation = detail.Quotation;
                    o.Dates = detail.OrderDate;
                    o.Deposit = detail.Deposit;
                    o.Balance = detail.Balance;
                    o.TotalAmount = detail.TotalAmount;
                    o.Status = detail.Status;
                    o.PaymentStatus = detail.PaymentStatus;
                    o.OrderType = detail.OrderType;
                    BindDataGrid();
                }
            }
        }
    }
}
