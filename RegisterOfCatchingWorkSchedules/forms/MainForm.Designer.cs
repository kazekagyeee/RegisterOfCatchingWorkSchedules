﻿namespace RegisterOfCatchingWorkSchedules
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
			this.btn_autorisation = new System.Windows.Forms.Button();
			this.btAddRecord = new System.Windows.Forms.Button();
			this.btRemoveRecord = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
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
            this.Status});
			this.dgvPlans.Location = new System.Drawing.Point(9, 44);
			this.dgvPlans.Margin = new System.Windows.Forms.Padding(2);
			this.dgvPlans.Name = "dgvPlans";
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
			this.ID.Visible = false;
			// 
			// Date
			// 
			this.Date.HeaderText = "Дата";
			this.Date.MinimumWidth = 6;
			this.Date.Name = "Date";
			this.Date.Width = 125;
			// 
			// Locality
			// 
			this.Locality.HeaderText = "Населённый пункт";
			this.Locality.MinimumWidth = 6;
			this.Locality.Name = "Locality";
			this.Locality.Width = 200;
			// 
			// Status
			// 
			this.Status.HeaderText = "Статус";
			this.Status.MinimumWidth = 6;
			this.Status.Name = "Status";
			this.Status.Width = 125;
			// 
			// btn_autorisation
			// 
			this.btn_autorisation.Location = new System.Drawing.Point(924, 10);
			this.btn_autorisation.Margin = new System.Windows.Forms.Padding(2);
			this.btn_autorisation.Name = "btn_autorisation";
			this.btn_autorisation.Size = new System.Drawing.Size(100, 29);
			this.btn_autorisation.TabIndex = 1;
			this.btn_autorisation.Text = "Авторизация";
			this.btn_autorisation.UseVisualStyleBackColor = true;
			this.btn_autorisation.Click += new System.EventHandler(this.OpenAuthForm);
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
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(293, 12);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Фильтры:";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(378, 15);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(92, 21);
			this.comboBox1.TabIndex = 5;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(473, 15);
			this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(92, 21);
			this.comboBox2.TabIndex = 6;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(568, 15);
			this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(92, 21);
			this.comboBox3.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1034, 410);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btRemoveRecord);
			this.Controls.Add(this.btAddRecord);
			this.Controls.Add(this.btn_autorisation);
			this.Controls.Add(this.dgvPlans);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "Главная";
			((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlans;
        private System.Windows.Forms.Button btn_autorisation;
        private System.Windows.Forms.Button btAddRecord;
        private System.Windows.Forms.Button btRemoveRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
	}
}
