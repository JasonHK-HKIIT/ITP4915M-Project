using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class ProductionDetailForm : Form
    {
        private readonly Dictionary<string, string> orderProductsDict = [];

        public ProductionDetailForm()
        {
            InitializeComponent();
            button1.Click += ButtonSave_Click;   // Save
            button2.Click += ButtonCancel_Click; // Cancel

            var ordersCommand = new MySqlCommand("SELECT CustomerOrderID, CustomerName, Quotation.ProductID, ProductName FROM CustomerOrder LEFT JOIN Customer ON CustomerOrder.CustomerID = Customer.CustomerID LEFT JOIN Quotation ON CustomerOrder.QuotationID = Quotation.QuotationID LEFT JOIN Product ON Quotation.ProductID = Product.ProductID", Program.Connection);
            var ordersReader = ordersCommand.ExecuteReader();
            var ordersDict = new Dictionary<string, string>();
            while (ordersReader.Read())
            {
                ordersDict.Add(ordersReader.GetString("CustomerOrderID"), $"{ordersReader["CustomerOrderID"]} - {ordersReader["CustomerName"]} - {ordersReader["ProductName"]}");
                orderProductsDict.Add(ordersReader.GetString("CustomerOrderID"), $"{ordersReader.GetString("ProductID")} - {ordersReader["ProductName"]}");
            }
            ordersReader.Close();
            textBox2.ValueMember = "Key";
            textBox2.DisplayMember = "Value";
            textBox2.DataSource = new BindingSource(ordersDict, null);

            comboBox1.SelectedIndex = 0;
        }

        // For editing: Fill fields
        public void SetFields(string id, string customerOrder, string product, int quantity, DateTime scheduledDate, string status)
        {
            maskedTextBox1.Text = id;
            textBox2.SelectedValue = customerOrder;
            textBox3.Text = orderProductsDict[customerOrder];
            textBox4.Text = quantity.ToString();
            dateTimePicker1.Value = scheduledDate;
            comboBox1.SelectedItem = status;
        }

        // For retrieving values after OK
        public string ProductionOrderID => maskedTextBox1.Text;
        public string CustomerOrderID => (string) textBox2.SelectedValue;
        public string ProductID => textBox3.Text.Substring(0, 7);
        public int Quantity => ((int)textBox4.Value);
        public DateTime ScheduledDate => dateTimePicker1.Value;
        public string Status => comboBox1.Text;

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ProductionDetailForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = orderProductsDict[(string)textBox2.SelectedValue];
        }
    }
}
