namespace RegisterOfCatchingWorkSchedules.View
{
	partial class StatusHistoryForm
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
			this.dgvHistory = new System.Windows.Forms.DataGridView();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Changes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvHistory
			// 
			this.dgvHistory.AllowUserToAddRows = false;
			this.dgvHistory.AllowUserToDeleteRows = false;
			this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Changes,
            this.Author});
			this.dgvHistory.Location = new System.Drawing.Point(12, 12);
			this.dgvHistory.Name = "dgvHistory";
			this.dgvHistory.Size = new System.Drawing.Size(348, 426);
			this.dgvHistory.TabIndex = 0;
			// 
			// Date
			// 
			this.Date.HeaderText = "Дата";
			this.Date.Name = "Date";
			this.Date.ReadOnly = true;
			// 
			// Changes
			// 
			this.Changes.HeaderText = "Статус";
			this.Changes.Name = "Changes";
			this.Changes.ReadOnly = true;
			// 
			// Author
			// 
			this.Author.HeaderText = "Пользователь";
			this.Author.Name = "Author";
			this.Author.ReadOnly = true;
			// 
			// StatusHistoryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 450);
			this.Controls.Add(this.dgvHistory);
			this.Name = "StatusHistoryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "История статусов записи";
			((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvHistory;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.DataGridViewTextBoxColumn Changes;
		private System.Windows.Forms.DataGridViewTextBoxColumn Author;
	}
}