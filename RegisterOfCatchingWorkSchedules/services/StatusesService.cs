using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules.Services
{
	public static class StatusesService
	{
		public static Statuses GetDefault()
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				return dbContext.Statuses.FirstOrDefault(x => x.StatusName == "Черновик");
			}
		}

		public static BindingList<Statuses> GetBindingList()
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				dbContext.Statuses.Load();
				return dbContext.Statuses.Local.ToBindingList();
			}
		}
	}
}
