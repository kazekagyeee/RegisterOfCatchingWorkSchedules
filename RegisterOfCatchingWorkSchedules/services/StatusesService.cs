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

		public static Statuses GetFinished()
        {
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
				return dbContext.Statuses.FirstOrDefault(x => x.StatusName == "Согласован в ОМСУ");
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

		public static BindingList<Statuses> GetAllowedStatuses()
        {
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
				var userRole = Program.Session.User.Roles;
				var rolePowers = dbContext.RolePowers
						.Where(x => x.RoleID == userRole.ID);
				var availableStatuses = rolePowers.Select(x => x.Statuses).ToList();
				return new BindingList<Statuses>(availableStatuses);
			}
        }
	}
}
