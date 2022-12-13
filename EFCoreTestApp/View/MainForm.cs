using System;
using System.Windows.Forms;

namespace EFCoreTestApp.View
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
			foreach (var plan in PlanController.GetAll())
				dgvPlans.Rows.Add(plan.Id, plan.Date, plan.Locality.Name, plan.Status.Name, plan.StatusChangeDate);
		}

		private void OpenAuthForm() => new AuthorizationForm().ShowDialog();

		private void OpenPlan(object sender, DataGridViewCellEventArgs e)
		{
			var id = (int)dgvPlans.Rows[e.RowIndex].Cells["ID"].Value;
			new RegisterRecordForm(PlanController.GetById(id)).ShowDialog();
			LoadPlansList();
		}

		private void OnAddRecord(object sender, EventArgs e)
		{
			new RegisterRecordForm(null).ShowDialog();
			LoadPlansList();
		}

		private void OnRemoveRecord(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы уверенны, что хотите удалить выделенные планы?", "Внимание!", MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;
			foreach (DataGridViewRow row in dgvPlans.SelectedRows)
				PlanController.Remove(PlanController.GetById((int)row.Cells["ID"].Value));
			LoadPlansList();
		}
	}
}
