using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CustomerForm : Form
    {
        public class Customer
        {
            public string CustomerID { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
        }
        private List<Customer> customers = new List<Customer>();

        public CustomerForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            // button3 for delete
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = customers.ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new CustomerDetailForm())
            {
                detail.Text = "Add Customer";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    customers.Add(new Customer
                    {
                        CustomerID = detail.CustomerID,
                        Name = detail.CustomerName,
                        Phone = detail.CustomerPhone,
                        Address = detail.CustomerAddress
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int idx = dataGridView1.SelectedRows[0].Index;
            var customer = customers[idx];
            using (var detail = new CustomerDetailForm())
            {
                detail.Text = "Edit Customer";
                detail.SetFields(customer.CustomerID, customer.Name, customer.Phone, customer.Address);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    customer.CustomerID = detail.CustomerID;
                    customer.Name = detail.CustomerName;
                    customer.Phone = detail.CustomerPhone;
                    customer.Address = detail.CustomerAddress;
                    BindDataGrid();
                }
            }
        }
    }

}
