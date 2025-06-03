using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class QuotationDetailForm : Form
    {
        private readonly bool IsEditMode = false;
        private readonly string QuotationId;

        public QuotationDetailForm()
        {
            InitializeComponent();
        }

        public QuotationDetailForm(string quotationId) : this()
        {
            IsEditMode = true;
            QuotationId = quotationId;
        }

        private void QuotationDetailForm_Load(object sender, EventArgs e)
        {
            var customersCcommand = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer", Program.Connection);
            var customersAdapter = new MySqlDataAdapter(customersCcommand);
            var customersTable = new DataTable();
            customersAdapter.Fill(customersTable);
            CustomerField.ValueMember = "CustomerID";
            CustomerField.DisplayMember = "CustomerName";
            CustomerField.DataSource = customersTable;

            var productsCommand = new MySqlCommand("SELECT ProductID, ProductName FROM Product", Program.Connection);
            var productsAdapter = new MySqlDataAdapter(productsCommand);
            var productsTable = new DataTable();
            productsAdapter.Fill(productsTable);
            ProductField.ValueMember = "ProductID";
            ProductField.DisplayMember = "ProductName";
            ProductField.DataSource = productsTable;

            if (IsEditMode)
            {
                var command = new MySqlCommand("SELECT * FROM Quotation WHERE QuotationID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", QuotationId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CustomerField.SelectedValue = reader["CustomerID"];
                    QuotationDateField.Value = (DateTime) reader["QuotationDate"];
                    ProductField.SelectedValue = reader["ProductID"];
                    QuantityField.Value = (int) reader["Quantity"];
                    StatusField.Text = (string) reader["Status"];
                    ValidityPeriodField.Value = (DateTime) reader["ValidityPeriod"];
                }
                reader.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
