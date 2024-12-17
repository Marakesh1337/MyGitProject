using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class ClientsForm : Form
    {
        private SQLiteConnection sqliteConn;

        public ClientsForm()
        {
            InitializeComponent();
            sqliteConn = new SQLiteConnection("Data Source=pharmacy.db;Version=3;");
            sqliteConn.Open();
            LoadClients();
        }

        private void LoadClients()
        {
            string query = "SELECT * FROM Clients";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, sqliteConn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            clientsDataGridView.DataSource = dataTable;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            string name = txtClientName.Text;
            string contact = txtClientContact.Text;

            string insertQuery = $"INSERT INTO Clients (Name, Contact) VALUES ('{name}', '{contact}')";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, sqliteConn);
            cmd.ExecuteNonQuery();
            LoadClients();
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(clientsDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            string deleteQuery = $"DELETE FROM Clients WHERE Id = {selectedId}";
            SQLiteCommand cmd = new SQLiteCommand(deleteQuery, sqliteConn);
            cmd.ExecuteNonQuery();
            LoadClients();
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(clientsDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            string name = txtClientName.Text;
            string contact = txtClientContact.Text;

            string updateQuery = $"UPDATE Clients SET Name = '{name}', Contact = '{contact}' WHERE Id = {selectedId}";
            SQLiteCommand cmd = new SQLiteCommand(updateQuery, sqliteConn);
            cmd.ExecuteNonQuery();
            LoadClients();
        }
    }
}
