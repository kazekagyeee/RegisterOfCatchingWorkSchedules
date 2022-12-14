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
			dgvPlans.Rows.Clear();
			foreach (var plan in PlanController.GetAllPlans())
			{
				dgvPlans.Rows.Add(
					plan.ID,
					plan.PlanDate.Value.ToString("MMMM yyyy"),
					plan.Municipality.MunicipalityName, 
					plan.Statuses.StatusName, 
					plan.StatusChangeDate);
			}
		}

		private void OpenAuthForm() => new AuthorizationForm().ShowDialog();

		private void AddRecord(object sender, EventArgs e)
		{
			new RegisterRecordForm(-1).ShowDialog();
			LoadPlansList();
		}

		private void RemovePlan(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvPlans.SelectedRows)
				PlanController.RemovePlan((int)row.Cells["ID"].Value);
			LoadPlansList();
		}

		private void OpenPlan(object sender, DataGridViewCellEventArgs e)
		{
			var id = (int)dgvPlans.Rows[e.RowIndex].Cells["ID"].Value;
			new RegisterRecordForm(id).ShowDialog();
			LoadPlansList();
		}
	}
}
