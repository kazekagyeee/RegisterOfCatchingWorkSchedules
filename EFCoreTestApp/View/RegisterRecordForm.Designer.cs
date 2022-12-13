namespace EFCoreTestApp.View
{
	partial class RegisterRecordForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.cbLocality = new System.Windows.Forms.ComboBox();
			this.btStatusHistory = new System.Windows.Forms.Button();
			this.dgvPlan = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(662, 28);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Статус";
			// 
			// cbStatus
			// 
			this.cbStatus.Enabled = false;
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Location = new System.Drawing.Point(665, 46);
			this.cbStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(300, 23);
			this.cbStatus.TabIndex = 2;
			this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.OnStatusChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 28);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Дата";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(300, 28);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 15);
			this.label4.TabIndex = 5;
			this.label4.Text = "Населённый пункт";
			// 
			// dtpDate
			// 
			this.dtpDate.CustomFormat = "MMMMyyyy";
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDate.Location = new System.Drawing.Point(35, 46);
			this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(233, 23);
			this.dtpDate.TabIndex = 11;
			this.dtpDate.ValueChanged += new System.EventHandler(this.OnDateChanged);
			// 
			// cbLocality
			// 
			this.cbLocality.FormattingEnabled = true;
			this.cbLocality.Location = new System.Drawing.Point(303, 46);
			this.cbLocality.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.cbLocality.Name = "cbLocality";
			this.cbLocality.Size = new System.Drawing.Size(322, 23);
			this.cbLocality.TabIndex = 12;
			this.cbLocality.SelectedIndexChanged += new System.EventHandler(this.OnMunicipalityChanged);
			// 
			// btStatusHistory
			// 
			this.btStatusHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btStatusHistory.Location = new System.Drawing.Point(1128, 43);
			this.btStatusHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btStatusHistory.Name = "btStatusHistory";
			this.btStatusHistory.Size = new System.Drawing.Size(189, 27);
			this.btStatusHistory.TabIndex = 13;
			this.btStatusHistory.Text = "Показать историю статусов";
			this.btStatusHistory.UseVisualStyleBackColor = true;
			this.btStatusHistory.Click += new System.EventHandler(this.OpenPlanHistory);
			// 
			// dgvPlan
			// 
			this.dgvPlan.AllowUserToAddRows = false;
			this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPlan.Enabled = false;
			this.dgvPlan.Location = new System.Drawing.Point(35, 103);
			this.dgvPlan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgvPlan.Name = "dgvPlan";
			this.dgvPlan.Size = new System.Drawing.Size(1282, 435);
			this.dgvPlan.TabIndex = 14;
			this.dgvPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnDataGridCellContentClick);
			this.dgvPlan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellValueChanged);
			this.dgvPlan.CurrentCellDirtyStateChanged += new System.EventHandler(this.CurrentCellDirtyStateChanged);
			this.dgvPlan.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.OnRowsAdded);
			this.dgvPlan.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.OnRowsRemoved);
			this.dgvPlan.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.OnDataGridRowRemoving);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(1212, 555);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(105, 27);
			this.button1.TabIndex = 15;
			this.button1.Text = "Сохранить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnSave);
			// 
			// RegisterRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1356, 588);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dgvPlan);
			this.Controls.Add(this.btStatusHistory);
			this.Controls.Add(this.cbLocality);
			this.Controls.Add(this.dtpDate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbStatus);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "RegisterRecordForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "План-график работ по отлову";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbStatus;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.ComboBox cbLocality;
		private System.Windows.Forms.Button btStatusHistory;
		private System.Windows.Forms.DataGridView dgvPlan;
		private System.Windows.Forms.Button button1;
	}
}