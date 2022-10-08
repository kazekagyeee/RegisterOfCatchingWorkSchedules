namespace RegisterOfCatchingWorkSchedules
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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbYear = new System.Windows.Forms.TextBox();
			this.tbMonth = new System.Windows.Forms.TextBox();
			this.tbPlace = new System.Windows.Forms.TextBox();
			this.tbCommentary = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(407, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Статус";
			// 
			// cbStatus
			// 
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Location = new System.Drawing.Point(410, 40);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(121, 21);
			this.cbStatus.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Год";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(152, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Месяц";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(282, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Населённый пункт";
			// 
			// tbYear
			// 
			this.tbYear.Location = new System.Drawing.Point(30, 41);
			this.tbYear.Name = "tbYear";
			this.tbYear.Size = new System.Drawing.Size(100, 20);
			this.tbYear.TabIndex = 6;
			// 
			// tbMonth
			// 
			this.tbMonth.Location = new System.Drawing.Point(155, 41);
			this.tbMonth.Name = "tbMonth";
			this.tbMonth.Size = new System.Drawing.Size(100, 20);
			this.tbMonth.TabIndex = 7;
			// 
			// tbPlace
			// 
			this.tbPlace.Location = new System.Drawing.Point(285, 41);
			this.tbPlace.Name = "tbPlace";
			this.tbPlace.Size = new System.Drawing.Size(100, 20);
			this.tbPlace.TabIndex = 8;
			// 
			// tbCommentary
			// 
			this.tbCommentary.Location = new System.Drawing.Point(30, 91);
			this.tbCommentary.Multiline = true;
			this.tbCommentary.Name = "tbCommentary";
			this.tbCommentary.Size = new System.Drawing.Size(501, 91);
			this.tbCommentary.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Комментарий";
			// 
			// RegisterRecord
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 194);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbCommentary);
			this.Controls.Add(this.tbPlace);
			this.Controls.Add(this.tbMonth);
			this.Controls.Add(this.tbYear);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbStatus);
			this.Controls.Add(this.label1);
			this.Name = "RegisterRecord";
			this.Text = "План-график работ по отлову";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbStatus;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbYear;
		private System.Windows.Forms.TextBox tbMonth;
		private System.Windows.Forms.TextBox tbPlace;
		private System.Windows.Forms.TextBox tbCommentary;
		private System.Windows.Forms.Label label5;
	}
}