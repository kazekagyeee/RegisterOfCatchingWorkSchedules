namespace RegisterOfCatchingWorkSchedules
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.dgvPlans = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatusChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btAddRecord = new System.Windows.Forms.Button();
			this.btRemoveRecord = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvPlans
			// 
			this.dgvPlans.AllowUserToAddRows = false;
			this.dgvPlans.AllowUserToDeleteRows = false;
			this.dgvPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPlans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Date,
            this.Locality,
            this.Status,
            this.StatusChangeDate});
			this.dgvPlans.Location = new System.Drawing.Point(9, 44);
			this.dgvPlans.Margin = new System.Windows.Forms.Padding(2);
			this.dgvPlans.Name = "dgvPlans";
			this.dgvPlans.ReadOnly = true;
			this.dgvPlans.RowHeadersWidth = 51;
			this.dgvPlans.RowTemplate.Height = 24;
			this.dgvPlans.Size = new System.Drawing.Size(1016, 356);
			this.dgvPlans.TabIndex = 0;
			this.dgvPlans.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OpenPlan);
			// 
			// ID
			// 
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			// 
			// Date
			// 
			this.Date.HeaderText = "Дата";
			this.Date.MinimumWidth = 6;
			this.Date.Name = "Date";
			this.Date.ReadOnly = true;
			this.Date.Width = 125;
			// 
			// Locality
			// 
			this.Locality.HeaderText = "Населённый пункт";
			this.Locality.MinimumWidth = 6;
			this.Locality.Name = "Locality";
			this.Locality.ReadOnly = true;
			this.Locality.Width = 300;
			// 
			// Status
			// 
			this.Status.HeaderText = "Статус";
			this.Status.MinimumWidth = 6;
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			this.Status.Width = 125;
			// 
			// StatusChangeDate
			// 
			this.StatusChangeDate.HeaderText = "Дата изменения статуса";
			this.StatusChangeDate.Name = "StatusChangeDate";
			this.StatusChangeDate.ReadOnly = true;
			this.StatusChangeDate.Width = 130;
			// 
			// btAddRecord
			// 
			this.btAddRecord.Location = new System.Drawing.Point(9, 10);
			this.btAddRecord.Margin = new System.Windows.Forms.Padding(2);
			this.btAddRecord.Name = "btAddRecord";
			this.btAddRecord.Size = new System.Drawing.Size(100, 29);
			this.btAddRecord.TabIndex = 2;
			this.btAddRecord.Text = "Добавить";
			this.btAddRecord.UseVisualStyleBackColor = true;
			this.btAddRecord.Click += new System.EventHandler(this.AddRecord);
			// 
			// btRemoveRecord
			// 
			this.btRemoveRecord.Location = new System.Drawing.Point(114, 10);
			this.btRemoveRecord.Margin = new System.Windows.Forms.Padding(2);
			this.btRemoveRecord.Name = "btRemoveRecord";
			this.btRemoveRecord.Size = new System.Drawing.Size(100, 29);
			this.btRemoveRecord.TabIndex = 3;
			this.btRemoveRecord.Text = "Удалить";
			this.btRemoveRecord.UseVisualStyleBackColor = true;
			this.btRemoveRecord.Click += new System.EventHandler(this.RemoveRecord);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1034, 410);
			this.Controls.Add(this.btRemoveRecord);
			this.Controls.Add(this.btAddRecord);
			this.Controls.Add(this.dgvPlans);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Главная";
			((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlans;
        private System.Windows.Forms.Button btAddRecord;
        private System.Windows.Forms.Button btRemoveRecord;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.DataGridViewTextBoxColumn StatusChangeDate;
	}
}

