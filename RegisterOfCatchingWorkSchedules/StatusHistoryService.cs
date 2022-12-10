using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public class StatusHistoryService
    {
        public List<StatusHistory> GetHistory(int planID)
        {
            return Program.DBContext.StatusHistory
                .Where(x => x.HistoryPlanID == planID)
                .ToList();
        }
    }
}
