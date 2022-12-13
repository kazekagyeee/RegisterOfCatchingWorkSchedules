using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public static class StatusHistoryService
    {
        public static List<StatusHistory> GetHistory(int planID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                return dbContext.StatusHistory
                    .Where(x => x.HistoryPlanID == planID)
                    .ToList();
            }
        }
        public static void AddHistoryLog(int statusID, int planID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var logToAdd = new StatusHistory();
                logToAdd.HistoryStatusID = statusID;
                logToAdd.HistoryPlanID = planID;
                logToAdd.HistoryDate = DateTime.Now;
                dbContext.StatusHistory.Add(logToAdd);
                dbContext.SaveChanges();
            } 
        }
    }
}
