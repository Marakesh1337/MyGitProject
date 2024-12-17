using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class OrdersForm : Form  // Наследование от Form
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления формы
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.ComboBox medsComboBox;
        private System.Windows.Forms.DataGridView ordersDataGridView;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnDeleteOrder;

        // Очистка ресурсов
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OrdersForm
            // 
            this.ClientSize = new System.Drawing.Size(304, 261);
            this.Name = "OrdersForm";
            this.ResumeLayout(false);

        }

        #endregion

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // Логика добавления заказа
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            // Логика удаления заказа
        }
    }
}
