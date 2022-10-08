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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_autorisation = new System.Windows.Forms.Button();
            this.btAddRecord = new System.Windows.Forms.Button();
            this.btRemoveRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Year,
            this.Month,
            this.Locality,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1355, 438);
            this.dataGridView1.TabIndex = 0;
            // 
            // Year
            // 
            this.Year.HeaderText = "Год";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.Width = 125;
            // 
            // Month
            // 
            this.Month.HeaderText = "Месяц";
            this.Month.MinimumWidth = 6;
            this.Month.Name = "Month";
            this.Month.Width = 125;
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
            this.btn_autorisation.Location = new System.Drawing.Point(1232, 12);
            this.btn_autorisation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_autorisation.Name = "btn_autorisation";
            this.btn_autorisation.Size = new System.Drawing.Size(133, 36);
            this.btn_autorisation.TabIndex = 1;
            this.btn_autorisation.Text = "Авторизация";
            this.btn_autorisation.UseVisualStyleBackColor = true;
            this.btn_autorisation.Click += new System.EventHandler(this.btn_autorisation_Click);
            // 
            // btAddRecord
            // 
            this.btAddRecord.Location = new System.Drawing.Point(12, 12);
            this.btAddRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddRecord.Name = "btAddRecord";
            this.btAddRecord.Size = new System.Drawing.Size(133, 36);
            this.btAddRecord.TabIndex = 2;
            this.btAddRecord.Text = "Добавить";
            this.btAddRecord.UseVisualStyleBackColor = true;
            this.btAddRecord.Click += new System.EventHandler(this.AddRecord);
            // 
            // btRemoveRecord
            // 
            this.btRemoveRecord.Location = new System.Drawing.Point(152, 12);
            this.btRemoveRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemoveRecord.Name = "btRemoveRecord";
            this.btRemoveRecord.Size = new System.Drawing.Size(133, 36);
            this.btRemoveRecord.TabIndex = 3;
            this.btRemoveRecord.Text = "Удалить";
            this.btRemoveRecord.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(375, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фильтры:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(488, 18);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(615, 18);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 6;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(741, 18);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 7;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(869, 18);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 24);
            this.comboBox4.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 505);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRemoveRecord);
            this.Controls.Add(this.btAddRecord);
            this.Controls.Add(this.btn_autorisation);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Реестр планов-графиков по отлову";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btn_autorisation;
        private System.Windows.Forms.Button btAddRecord;
        private System.Windows.Forms.Button btRemoveRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
    }
}

