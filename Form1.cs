using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class Form1 : Form  // Наследуем от Form
    {
        private Database database; // Создадим экземпляр класса Database для работы с БД

        public Form1()
        {
            InitializeComponent();
            database = new Database(); // Инициализируем объект для работы с базой данных
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация базы данных при загрузке формы
            database.InitializeDatabase();
        }
    }

    public class Database
    {
        private SQLiteConnection sqliteConn;

        public void InitializeDatabase()
        {
            sqliteConn = new SQLiteConnection("Data Source=pharmacy.db;Version=3;");
            sqliteConn.Open();

            // Создание таблиц, если они еще не существуют
            string createMedsTable = "CREATE TABLE IF NOT EXISTS Meds (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Form TEXT, Price REAL, Quantity INTEGER)";
            string createOrdersTable = "CREATE TABLE IF NOT EXISTS Orders (Id INTEGER PRIMARY KEY AUTOINCREMENT, ClientId INTEGER, OrderDate DATETIME, Status TEXT)";
            string createClientsTable = "CREATE TABLE IF NOT EXISTS Clients (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Contact TEXT)";
            string createEmployeesTable = "CREATE TABLE IF NOT EXISTS Employees (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Position TEXT, Login TEXT, Password TEXT)";

            SQLiteCommand cmd = new SQLiteCommand(createMedsTable, sqliteConn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(createOrdersTable, sqliteConn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(createClientsTable, sqliteConn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(createEmployeesTable, sqliteConn);
            cmd.ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            sqliteConn.Close();
        }
    }
}
