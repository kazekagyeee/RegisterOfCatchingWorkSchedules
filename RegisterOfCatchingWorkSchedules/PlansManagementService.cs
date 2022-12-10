using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public class PlansManagementService
    {
        public List<Plans> GetAllowedPlans()
        {
            var userRole = Program.Session.User.Roles;
            if (userRole != null)
            {
                var rolePowers = Program.DBContext.RolePowers
                    .Where(x => x.RoleID == userRole.ID)
                    .ToList();
                var availableStatuses = rolePowers.Select(x => x.Statuses).ToList();
                return GetPlansWithStatuses(availableStatuses);
            }
            else
            {
                var availableStatuses = Program.DBContext.Statuses.Where(x => x.StatusName == "Done").ToList();
                return GetPlansWithStatuses(availableStatuses);
            }
        }

        private static List<Plans> GetPlansWithStatuses(List<Statuses> availableStatuses)
        {
            return Program.DBContext.Plans
                                .Where(x => availableStatuses.Any(s => s.ID == x.PlanStatusID))
                                .ToList();
        }
    }
}
