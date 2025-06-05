using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class ProductDetailForm : Form
    {
        private readonly bool IsEditMode = false;
        private readonly string ProductId;

        public ProductDetailForm()
        {
            InitializeComponent();
        }

        public ProductDetailForm(string productId) : this()
        {
            IsEditMode = true;
            ProductId = productId;
        }

        private void ProductDetailForm_Load(object sender, EventArgs e)
        {
            var requestsCommand = new MySqlCommand("SELECT DesignRequestID, Specifications FROM ProductDesignRequest", Program.Connection);
            var requestsReader = requestsCommand.ExecuteReader();
            var requestsDict = new Dictionary<string, string>();
            while (requestsReader.Read())
            {
                requestsDict.Add((string)requestsReader["DesignRequestID"], $"{requestsReader["DesignRequestID"]} - {requestsReader["Specifications"]}");
            }
            requestsReader.Close();
            DesignRequestField.ValueMember = "Key";
            DesignRequestField.DisplayMember = "Value";
            DesignRequestField.DataSource = new BindingSource(requestsDict, null);

            if (IsEditMode)
            {
                var command = new MySqlCommand("SELECT * FROM Product WHERE ProductID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", ProductId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ProductIdField.Text = (string)reader["ProductID"];
                    DesignRequestField.SelectedValue = reader["DesignRequestID"];
                    NameField.Text = (string)reader["ProductName"];
                    TypeField.Text = (string)reader["ProductType"];
                    UnitPriceField.Value = (decimal)reader["UnitPrice"];
                    SpecificationsField.Text = (string)reader["ProductSpecifications"];
                }
                reader.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsEditMode)
                {
                    var command = new MySqlCommand("UPDATE Product SET DesignRequestID = ?designRequest, ProductName = ?name, ProductType = ?type, UnitPrice = ?price, ProductSpecifications = ?specifications WHERE ProductID = ?id", Program.Connection);
                    command.Parameters.AddWithValue("?id", ProductId);
                    command.Parameters.AddWithValue("?designRequest", DesignRequestField.SelectedValue);
                    command.Parameters.AddWithValue("?name", NameField.Text);
                    command.Parameters.AddWithValue("?type", TypeField.Text);
                    command.Parameters.AddWithValue("?price", UnitPriceField.Value);
                    command.Parameters.AddWithValue("?specifications", SpecificationsField.Text);
                    command.ExecuteNonQuery();
                }
                else
                {
                    var command = new MySqlCommand("INSERT INTO Product (ProductID, DesignRequestID, ProductName, ProductType, UnitPrice, ProductSpecifications) VALUES (?id, ?designRequest, ?name, ?type, ?price, ?specifications)", Program.Connection);
                    command.Parameters.AddWithValue("?id", ProductIdField.Text);
                    command.Parameters.AddWithValue("?designRequest", DesignRequestField.SelectedValue);
                    command.Parameters.AddWithValue("?name", NameField.Text);
                    command.Parameters.AddWithValue("?type", TypeField.Text);
                    command.Parameters.AddWithValue("?price", UnitPriceField.Value);
                    command.Parameters.AddWithValue("?specifications", SpecificationsField.Text);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
