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
                    QuotationIdField.Text = (string) reader["QuotationID"];
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

            var productCommand = new MySqlCommand("SELECT UnitPrice FROM Product WHERE ProductID = ?product", Program.Connection);
            productCommand.Parameters.AddWithValue("?product", ProductField.SelectedValue);
            var productReader = productCommand.ExecuteReader();
            if (!productReader.Read())
            {
                MessageBox.Show("Selected product does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                productReader.Close();
                return;
            }
            decimal unitPrice = (decimal)productReader["UnitPrice"];
            productReader.Close();

            if (IsEditMode)
            {
                var command = new MySqlCommand("UPDATE Quotation SET CustomerID = ?customer, QuotationDate = ?date, ProductID = ?product, Quantity = ?quantity, Status = ?status, ValidityPeriod = ?validity, TotalAmount = ?totalAmount WHERE QuotationID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", QuotationIdField.Text);
                command.Parameters.AddWithValue("?customer", CustomerField.SelectedValue);
                command.Parameters.AddWithValue("?date", QuotationDateField.Value);
                command.Parameters.AddWithValue("?product", ProductField.SelectedValue);
                command.Parameters.AddWithValue("?quantity", QuantityField.Value);
                command.Parameters.AddWithValue("?status", StatusField.Text);
                command.Parameters.AddWithValue("?validity", ValidityPeriodField.Value);
                command.Parameters.AddWithValue("?totalAmount", unitPrice * QuantityField.Value);
                command.ExecuteNonQuery();
            }
            else
            {
                var command = new MySqlCommand("INSERT INTO Quotation (QuotationID, CustomerID, QuotationDate, ProductID, Quantity, Status, ValidityPeriod, TotalAmount) VALUES (?quotationID, ?customer, ?date, ?product, ?quantity, ?status, ?validity, ?totalAmount)", Program.Connection);
                command.Parameters.AddWithValue("?quotationID", QuotationIdField.Text);
                command.Parameters.AddWithValue("?customer", CustomerField.SelectedValue);
                command.Parameters.AddWithValue("?date", QuotationDateField.Value);
                command.Parameters.AddWithValue("?product", ProductField.SelectedValue);
                command.Parameters.AddWithValue("?quantity", QuantityField.Value);
                command.Parameters.AddWithValue("?status", StatusField.Text);
                command.Parameters.AddWithValue("?validity", ValidityPeriodField.Value);
                command.Parameters.AddWithValue("?totalAmount", unitPrice * QuantityField.Value);
                command.ExecuteNonQuery();
            }

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
