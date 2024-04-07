namespace Veterinary
{
    partial class FormVetRecords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVetRecords));
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id_record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_users = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_pet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.veterinarian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_record,
            this.id_users,
            this.id_pet,
            this.id_service,
            this.date,
            this.time,
            this.veterinarian});
            this.dataGridView2.Location = new System.Drawing.Point(10, 12);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(650, 467);
            this.dataGridView2.TabIndex = 34;
            // 
            // id_record
            // 
            this.id_record.DataPropertyName = "id_record";
            this.id_record.HeaderText = "id_record";
            this.id_record.Name = "id_record";
            this.id_record.ReadOnly = true;
            this.id_record.Visible = false;
            // 
            // id_users
            // 
            this.id_users.DataPropertyName = "id_users";
            this.id_users.HeaderText = "ID клиента";
            this.id_users.Name = "id_users";
            this.id_users.ReadOnly = true;
            this.id_users.Width = 72;
            // 
            // id_pet
            // 
            this.id_pet.DataPropertyName = "id_pet";
            this.id_pet.HeaderText = "ID питомца";
            this.id_pet.Name = "id_pet";
            this.id_pet.ReadOnly = true;
            this.id_pet.Width = 75;
            // 
            // id_service
            // 
            this.id_service.DataPropertyName = "id_service";
            this.id_service.HeaderText = "ID услуги";
            this.id_service.Name = "id_service";
            this.id_service.ReadOnly = true;
            this.id_service.Width = 60;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Дата";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "Время";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // veterinarian
            // 
            this.veterinarian.DataPropertyName = "veterinarian";
            this.veterinarian.HeaderText = "Ветеринар";
            this.veterinarian.Name = "veterinarian";
            this.veterinarian.ReadOnly = true;
            this.veterinarian.Width = 200;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(663, 12);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 52);
            this.button4.TabIndex = 35;
            this.button4.Text = "Выход";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormVetRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView2);
            this.Font = new System.Drawing.Font("Bookman Old Style", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormVetRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель ветеринара | просмотр записей на приём";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_record;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_users;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pet;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn veterinarian;
        private System.Windows.Forms.Button button4;
    }
}