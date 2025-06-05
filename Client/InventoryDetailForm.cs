using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class InventoryDetailForm : Form
    {
        public InventoryDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            this.Load += InventoryDetailForm_Load;
        }

        private void InventoryDetailForm_Load(object sender, EventArgs e)
        {
            // Fill Warehouse ComboBox
            using (var cmd = new MySqlCommand("SELECT WarehouseID, WarehouseAddress FROM Warehouse", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "WarehouseID"; // or "WarehouseAddress" if you want addresses
                comboBox1.ValueMember = "WarehouseID";
            }

            // Fill Product ComboBox
            using (var cmd = new MySqlCommand("SELECT ProductID, ProductName FROM Product", Program.Connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "ProductID"; // or "ProductName" if you want names
                comboBox2.ValueMember = "ProductID";
            }
        }

        public void SetFields(string warehouse, string product, int qty, int reorder, int min)
        {
            comboBox1.SelectedValue = warehouse;
            comboBox2.SelectedValue = product;
            textBox1.Text = qty.ToString();
            textBox2.Text = reorder.ToString();
            textBox3.Text = min.ToString();
        }

        public string Warehouse => comboBox1.SelectedValue?.ToString() ?? "";
        public string Product => comboBox2.SelectedValue?.ToString() ?? "";
        public int Quantity => int.TryParse(textBox1.Text, out int q) ? q : 0;
        public int ReorderPoint => int.TryParse(textBox2.Text, out int r) ? r : 0;
        public int MinimumStock => int.TryParse(textBox3.Text, out int min) ? min : 0;
    }
}
