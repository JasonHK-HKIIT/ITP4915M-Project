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
                var command = new MySqlCommand("SELECT MaterialID, MaterialName, Description, QuantityPerUnit FROM Material WHERE MaterialID = ?id", Program.Connection);
                command.Parameters.AddWithValue("?id", MaterialId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MaterialIdField.Text = reader.GetString("MaterialID");
                    NameField.Text = reader.GetString("MaterialName");
                    DescriptionField.Text = reader.IsDBNull("Description") ? "" : reader.GetString("Description");
                    QuantityPerUnitField.Value = reader.GetDecimal("QuantityPerUnit");
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
                command = new MySqlCommand("UPDATE Material SET MaterialName = ?name, Description = ?description, QuantityPerUnit = ?quantity WHERE MaterialID = ?id", Program.Connection);
            }
            else
            {
                var lastIdCommand = new MySqlCommand("SELECT MaterialID FROM Material ORDER BY MaterialID DESC LIMIT 1", Program.Connection);
                var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "MAT000";
                var nextId = int.Parse(lastIdString.Substring(3)) + 1;
                materialId = $"MAT{nextId:D3}";

                command = new MySqlCommand("INSERT INTO Material (MaterialID, MaterialName, Description, QuantityPerUnit) VALUES (?id, ?name, ?description, ?quantity)", Program.Connection);
            }

            command.Parameters.AddWithValue("?id", materialId);
            command.Parameters.AddWithValue("?name", NameField.Text);
            command.Parameters.AddWithValue("?description", DescriptionField.Text);
            command.Parameters.AddWithValue("?quantity", QuantityPerUnitField.Value);
            
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
