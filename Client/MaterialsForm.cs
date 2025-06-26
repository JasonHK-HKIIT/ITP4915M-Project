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
    public partial class MaterialsForm : Form
    {
        public MaterialsForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var command = new MySqlCommand(
                "SELECT * FROM Material WHERE MaterialID LIKE ?query OR MaterialName LIKE ?query",
                Program.Connection
            );
            command.Parameters.AddWithValue("?query", $"%{SearchField.Text}%");
            var adapter = new MySqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            MaterialsView.DataSource = table;
        }

        private void MaterialsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SearchField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadData();
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            var form = new MaterialDetailsForm();
            form.ShowDialog();
            LoadData();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (MaterialsView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a material to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new MaterialDetailsForm((string)MaterialsView.SelectedRows[0].Cells["MaterialID"].Value);
            form.ShowDialog();
            LoadData();
        }
    }
}
