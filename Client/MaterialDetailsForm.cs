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
    public partial class MaterialDetailsForm : Form
    {
        private readonly bool IsEditMode = false;
        private readonly string MaterialId = null;

        public MaterialDetailsForm()
        {
            InitializeComponent();

            this.Text = "Material Details Form";
        }

        public MaterialDetailsForm(string materialId) : this()
        {
            IsEditMode = true;
            MaterialId = materialId;
        }

        private void MaterialDetailsForm_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                var command = new MySqlCommand("SELECT MaterialID, MaterialName, Description, PricePerUnit FROM Material WHERE MaterialID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", MaterialId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MaterialIdField.Text = reader.GetString("MaterialID");
                    NameField.Text = reader.GetString("MaterialName");
                    DescriptionField.Text = reader.IsDBNull("Description") ? "" : reader.GetString("Description");
                    PricePerUnitField.Value = reader.GetDecimal("PricePerUnit");
                }
                reader.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string materialId;
            MySqlCommand command;
            if (IsEditMode)
            {
                materialId = MaterialId;
                command = new MySqlCommand("UPDATE Material SET MaterialName = ?name, Description = ?description, PricePerUnit = ?price WHERE MaterialID = ?id", Program.Connection);
            }
            else
            {
                var lastIdCommand = new MySqlCommand("SELECT MaterialID FROM Material ORDER BY MaterialID DESC LIMIT 1", Program.Connection);
                var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "MAT000";
                var nextId = int.Parse(lastIdString.Substring(3)) + 1;
                materialId = $"MAT{nextId:D3}";

                command = new MySqlCommand("INSERT INTO Material (MaterialID, MaterialName, Description, PricePerUnit) VALUES (?id, ?name, ?description, ?price)", Program.Connection);
            }

            command.Parameters.AddWithValue("?id", materialId);
            command.Parameters.AddWithValue("?name", NameField.Text);
            command.Parameters.AddWithValue("?description", DescriptionField.Text);
            command.Parameters.AddWithValue("?price", PricePerUnitField.Value);
            
            try
            {
                command.ExecuteNonQuery();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error saving material: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
