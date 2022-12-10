using System;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void AddRecord(object sender, EventArgs e) => new RegisterRecordForm().ShowDialog();

		private void OpenAuthForm(object sender, EventArgs e) => new AuthorizationForm().ShowDialog();

		private void RemoveRecord(object sender, EventArgs e)
		{
			if (PlanController.TryRemovePlan())
			{

			}
			else
			{
				MessageBox.Show("Ошибка")
			}
		}
	}
}
