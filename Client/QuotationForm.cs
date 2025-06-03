using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class QuotationForm : Form
    {
        // Quotation Data Model
        public class Quotation
        {
            public string Customer { get; set; }
            public string Product { get; set; }
            public int Quantity { get; set; }
            public string Validity { get; set; }
            public string Status { get; set; }
        }

        private List<Quotation> quotations = new List<Quotation>();

        public QuotationForm()
        {
            InitializeComponent();
            button3.Click += ButtonAdd_Click;   // "Add Quotation"
            button2.Click += ButtonEdit_Click;  // "Edit Selected"
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = quotations.Select(q => new
            {
                q.Customer,
                q.Product,
                q.Quantity,
                q.Validity,
                q.Status
            }).ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new QuotationDetailForm())
            {
                detail.Text = "Add Quotation";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    quotations.Add(new Quotation
                    {
                        Customer = detail.Customer,
                        Product = detail.Product,
                        Quantity = detail.Quantity,
                        Validity = detail.Validity,
                        Status = detail.Status
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a quotation to edit.");
                return;
            }
            int idx = dataGridView1.SelectedRows[0].Index;
            var q = quotations[idx];
            using (var detail = new QuotationDetailForm())
            {
                detail.Text = "Edit Quotation";
                detail.SetFields(q.Customer, q.Product, q.Quantity, q.Validity, q.Status);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    q.Customer = detail.Customer;
                    q.Product = detail.Product;
                    q.Quantity = detail.Quantity;
                    q.Validity = detail.Validity;
                    q.Status = detail.Status;
                    BindDataGrid();
                }
            }
        }
    }
}
