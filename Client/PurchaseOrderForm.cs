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
    public partial class PurchaseOrderForm : Form
    {
        public class PurchaseOrder
        {
            public string PONumber { get; set; }
            public string Supplier { get; set; }
            public DateTime PODate { get; set; }
            public string Status { get; set; }
        }

        private List<PurchaseOrder> orders = new List<PurchaseOrder>();

        public PurchaseOrderForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            // button3 for "View PO Lines"
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orders.ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new PurchaseOrderDetailForm())
            {
                detail.Text = "Add Purchase Order";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    orders.Add(new PurchaseOrder
                    {
                        PONumber = detail.PONumber,
                        Supplier = detail.Supplier,
                        PODate = detail.PODate,
                        Status = detail.Status
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int idx = dataGridView1.SelectedRows[0].Index;
            var order = orders[idx];
            using (var detail = new PurchaseOrderDetailForm())
            {
                detail.Text = "Edit Purchase Order";
                detail.SetFields(order.PONumber, order.Supplier, order.PODate, order.Status);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    order.PONumber = detail.PONumber;
                    order.Supplier = detail.Supplier;
                    order.PODate = detail.PODate;
                    order.Status = detail.Status;
                    BindDataGrid();
                }
            }
        }
    }
