using System;
using System.Linq;
using System.Data.Entity;

namespace RegisterOfCatchingWorkSchedules.Services
{
	public static class StatusHistoryService
	{
		public static StatusHistory[] GetHistory(int planID)
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
				return dbContext.StatusHistory
					.Include(x => x.Statuses)
					.Where(x => x.HistoryPlanID == planID)
					.ToArray();
		}

		public static void AddHistoryLog(int statusID, int planID)
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				var logToAdd = new StatusHistory
				{
					HistoryStatusID = statusID,
					HistoryPlanID = planID,
					HistoryDate = DateTime.Now
				};
				dbContext.StatusHistory.Add(logToAdd);
				dbContext.SaveChanges();
			}
		}
	}
}
