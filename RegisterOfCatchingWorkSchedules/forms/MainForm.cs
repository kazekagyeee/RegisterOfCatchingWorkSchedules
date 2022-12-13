using System;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			OpenAuthForm();
			LoadPlansList();
		}

		private void LoadPlansList()
		{
			foreach (var plan in PlanController.GetAllPlans())
			{
				dgvPlans.Rows.Add(plan.ID, plan.PlanDate, plan.Municipality.MunicipalityName, plan.Statuses.StatusName, plan.StatusChangeDate);
			}
		}

		private void OpenAuthForm() => new AuthorizationForm().ShowDialog();

		private void AddRecord(object sender, EventArgs e) => new RegisterRecordForm(-1).ShowDialog();

		private void RemoveRecord(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvPlans.SelectedRows)
			{
				if (PlanController.TryRemovePlan((int)row.Cells["ID"].Value))
				{

				}
				else
				{
					MessageBox.Show("Ошибка");
				}
			}
		}

		private void OpenPlan(object sender, DataGridViewCellEventArgs e)
		{
			var id = (int)dgvPlans.Rows[e.RowIndex].Cells["ID"].Value;
			new RegisterRecordForm(id).ShowDialog();
		}
	}
}
