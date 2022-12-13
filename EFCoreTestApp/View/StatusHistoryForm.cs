using EFCoreTestApp.Model;
using System.Windows.Forms;

namespace EFCoreTestApp.View
{
	public partial class StatusHistoryForm : Form
	{
		public StatusHistoryForm(Plan plan)
		{
			InitializeComponent();
			LoadData(plan);
		}

		private void LoadData(Plan plan)
		{
			var historyData = PlanController.GetStatusHistory(plan);
			foreach (var rec in historyData)
				dgvHistory.Rows.Add(rec.Date, rec.Status.Name);
		}
	}
}
