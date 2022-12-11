using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	public partial class StatusHistoryForm : Form
	{
		public StatusHistoryForm(int planId)
		{
			InitializeComponent();
			LoadData(planId);
		}

		private void LoadData(int planId)
		{
			var historyData = PlanController.GetStatusHistory(planId);
			foreach (var rec in historyData)
			{
				dgvHistory.Rows.Add(rec.HistoryDate, rec.Statuses.StatusName);
			}
		}
	}
}
