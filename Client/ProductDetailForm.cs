using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class ProductDetailForm : Form
    {
        private bool IsEditMode = false;
        private string ProductId;

        public ProductDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };    // Save
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };// Cancel
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
                requestsDict.Add((string) requestsReader["DesignRequestID"], $"{requestsReader["DesignRequestID"]} - {requestsReader["Specifications"]}");
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
                    DesignRequestField.SelectedValue = reader["DesignRequestID"];
                    NameField.Text = (string) reader["ProductName"];
                    TypeField.Text = (string) reader["ProductType"];
                    UnitPriceField.Value = (decimal) reader["UnitPrice"];
                    SpecificationsField.Text = (string) reader["ProductSpecifications"];
                }
                reader.Close();
            }
        }

        // Use these to retrieve data after Save
        public string LinkedDesignRequest => DesignRequestField.Text;
        public string ProductName => NameField.Text;
        public string ProductType => TypeField.Text;
        public string UnitPrice => textBox4.Text;
        public string Specifications => SpecificationsField.Text;
    }
}
