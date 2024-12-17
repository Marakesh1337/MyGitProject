using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

public partial class OrdersForm : Form
{
    private SQLiteConnection sqliteConn;
    private DataGridView ordersDataGridView;
    private ComboBox clientComboBox;
    private ComboBox medsComboBox;
    private Button btnAddOrder;
    private Button btnDeleteOrder;

    public OrdersForm()
    {
        InitializeComponent();
        sqliteConn = new SQLiteConnection("Data Source=pharmacy.db;Version=3;");
        sqliteConn.Open();
        LoadOrders();
        LoadClients();
        LoadMeds();
    }

    private void InitializeComponent()
    {
        // Инициализация элементов управления
        this.ordersDataGridView = new DataGridView();
        this.clientComboBox = new ComboBox();
        this.medsComboBox = new ComboBox();
        this.btnAddOrder = new Button();
        this.btnDeleteOrder = new Button();

        // Настройка ordersDataGridView
        this.ordersDataGridView.Location = new System.Drawing.Point(10, 10);
        this.ordersDataGridView.Size = new System.Drawing.Size(400, 200);

        // Настройка clientComboBox
        this.clientComboBox.Location = new System.Drawing.Point(10, 220);
        this.clientComboBox.Size = new System.Drawing.Size(200, 30);

        // Настройка medsComboBox
        this.medsComboBox.Location = new System.Drawing.Point(10, 260);
        this.medsComboBox.Size = new System.Drawing.Size(200, 30);

        // Настройка btnAddOrder
        this.btnAddOrder.Text = "Добавить заказ";
        this.btnAddOrder.Location = new System.Drawing.Point(10, 300);
        this.btnAddOrder.Size = new System.Drawing.Size(150, 30);
        this.btnAddOrder.Click += new EventHandler(btnAddOrder_Click);

        // Настройка btnDeleteOrder
        this.btnDeleteOrder.Text = "Удалить заказ";
        this.btnDeleteOrder.Location = new System.Drawing.Point(170, 300);
        this.btnDeleteOrder.Size = new System.Drawing.Size(150, 30);
        this.btnDeleteOrder.Click += new EventHandler(btnDeleteOrder_Click);

        // Добавление элементов на форму
        this.Controls.Add(this.ordersDataGridView);
        this.Controls.Add(this.clientComboBox);
        this.Controls.Add(this.medsComboBox);
        this.Controls.Add(this.btnAddOrder);
        this.Controls.Add(this.btnDeleteOrder);
    }

    private void LoadOrders()
    {
        string query = "SELECT * FROM Orders";
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, sqliteConn);
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);
        ordersDataGridView.DataSource = dataTable;
    }

    private void LoadClients()
    {
        string query = "SELECT Id, Name FROM Clients";
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, sqliteConn);
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);
        clientComboBox.DataSource = dataTable;
        clientComboBox.DisplayMember = "Name";
        clientComboBox.ValueMember = "Id";
    }

    private void LoadMeds()
    {
        string query = "SELECT Id, Name FROM Meds";
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, sqliteConn);
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);
        medsComboBox.DataSource = dataTable;
        medsComboBox.DisplayMember = "Name";
        medsComboBox.ValueMember = "Id";
    }

    private void btnAddOrder_Click(object sender, EventArgs e)
    {
        int clientId = (int)clientComboBox.SelectedValue;
        int medId = (int)medsComboBox.SelectedValue;
        string status = "В ожидании";
        DateTime orderDate = DateTime.Now;

        string insertQuery = $"INSERT INTO Orders (ClientId, OrderDate, Status) VALUES ({clientId}, '{orderDate}', '{status}')";
        SQLiteCommand cmd = new SQLiteCommand(insertQuery, sqliteConn);
        cmd.ExecuteNonQuery();

        // После добавления заказа, нужно обновить отображение списка заказов
        LoadOrders();
    }

    private void btnDeleteOrder_Click(object sender, EventArgs e)
    {
        int selectedId = int.Parse(ordersDataGridView.SelectedRows[0].Cells[0].Value.ToString());
        string deleteQuery = $"DELETE FROM Orders WHERE Id = {selectedId}";
        SQLiteCommand cmd = new SQLiteCommand(deleteQuery, sqliteConn);
        cmd.ExecuteNonQuery();
        LoadOrders();
    }
}
