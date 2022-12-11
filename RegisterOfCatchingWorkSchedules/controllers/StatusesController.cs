using System.ComponentModel;
using System.Data.Entity;

namespace RegisterOfCatchingWorkSchedules
{
	public static class StatusesController
	{
		public static BindingList<Statuses> GetStatusesBindingList()
		{
			Program.DBContext.Statuses.Load();
			return Program.DBContext.Statuses.Local.ToBindingList();
		}
	}
}
