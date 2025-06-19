using MySql.Data.MySqlClient;
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
    public partial class ShipmentDetailForm : Form
    {
        public ShipmentDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            var ordersCommand = new MySqlCommand("SELECT CustomerOrderID, CustomerName, Quotation.ProductID, ProductName FROM CustomerOrder LEFT JOIN Customer ON CustomerOrder.CustomerID = Customer.CustomerID LEFT JOIN Quotation ON CustomerOrder.QuotationID = Quotation.QuotationID LEFT JOIN Product ON Quotation.ProductID = Product.ProductID", Program.Connection);
            var ordersReader = ordersCommand.ExecuteReader();
            var ordersDict = new Dictionary<string, string>();
            while (ordersReader.Read())
            {
                ordersDict.Add(ordersReader.GetString("CustomerOrderID"), $"{ordersReader["CustomerOrderID"]} - {ordersReader["CustomerName"]} - {ordersReader["ProductName"]}");
            }
            ordersReader.Close();
            textBox2.ValueMember = "Key";
            textBox2.DisplayMember = "Value";
            textBox2.DataSource = new BindingSource(ordersDict, null);

            comboBox1.SelectedIndex = 0;
        }

        public void SetFields(string id, string order, string carrier, string tracking, DateTime date, string status,DateTime issueDate)
        {
            maskedTextBox1.Text = id;
            textBox2.SelectedValue = order;
            textBox3.Text = carrier;
            textBox4.Text = tracking;
            dateTimePicker1.Value = date;
            comboBox1.SelectedItem = status;
            dateTimePicker2.Value = issueDate;
        }

        private void ShipmentDetailForm_Load(object sender, EventArgs e)
        {

        }

        public string ShipmentID => maskedTextBox1.Text;
        public string CustomerOrderID => (string)textBox2.SelectedValue;
        public string Carrier => textBox3.Text;
        public string TrackingNumber => textBox4.Text;
        public DateTime ShipmentDate => dateTimePicker1.Value;
        public string Status => (string)comboBox1.SelectedItem;
        public DateTime IssueDate => dateTimePicker2.Value;
    }
}