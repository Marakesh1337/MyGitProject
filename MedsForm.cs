using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace WindowsFormsApp25
{
    public partial class MedsForm : Form
    {
        private SQLiteConnection sqliteConn;

        public MedsForm()
        {
            
            sqliteConn = new SQLiteConnection("Data Source=pharmacy.db;Version=3;");
            sqliteConn.Open();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string form = txtForm.Text;
            double price;
            int quantity;

            if (double.TryParse(txtPrice.Text, out price) && int.TryParse(txtQuantity.Text, out quantity))
            {
                string insertQuery = $"INSERT INTO Meds (Name, Form, Price, Quantity) VALUES ('{name}', '{form}', {price}, {quantity})";
                SQLiteCommand cmd = new SQLiteCommand(insertQuery, sqliteConn);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Data saved: Name = {name}, Form = {form}, Price = {price}, Quantity = {quantity}");
                LoadMeds(); // After saving, reload the data grid
            }
            else
            {
                MessageBox.Show("Invalid data input!");
            }
        }

        private void LoadMeds()
        {
            string query = "SELECT * FROM Meds";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, sqliteConn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            medsDataGridView.DataSource = dataTable;
        }

        private void MedsForm_Load(object sender, EventArgs e)
        {
            LoadMeds(); // Load data when form is loaded
        }
    }
}
