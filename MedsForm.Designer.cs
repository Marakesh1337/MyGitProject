using System.Windows.Forms;

namespace WindowsFormsApp25
{
    partial class MedsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView medsDataGridView;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtForm;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.medsDataGridView = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtForm = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.medsDataGridView)).BeginInit();
            this.SuspendLayout();

            // medsDataGridView
            this.medsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medsDataGridView.Location = new System.Drawing.Point(12, 118);
            this.medsDataGridView.Name = "medsDataGridView";
            this.medsDataGridView.Size = new System.Drawing.Size(240, 150);

            // txtName
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Size = new System.Drawing.Size(100, 20);

            // txtForm
            this.txtForm.Location = new System.Drawing.Point(12, 38);
            this.txtForm.Size = new System.Drawing.Size(100, 20);

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(12, 64);
            this.txtPrice.Size = new System.Drawing.Size(100, 20);

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(12, 90);
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(174, 118);
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // MedsForm
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.medsDataGridView);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtForm);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnSave);
            this.Name = "MedsForm";
            this.Load += new System.EventHandler(this.MedsForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.medsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}