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

        public void DeletePlan(int planID)
        {
            var planToRemove = Program.DBContext.Plans.FirstOrDefault(x => x.ID == planID);
            Program.DBContext.Plans.Remove(planToRemove);
        }

        public int CreatePlan(DateTime planDate, Places place)
        {
            var plan = new Plans();
            plan.PlanStatusID = Program.DBContext.Statuses.FirstOrDefault(x => x.StatusName == "Draft").ID;
            plan.PlanDate = planDate;
            plan.StatusChangeDate = DateTime.Now;
            plan.OrganisationID = Program.Session.User.Organisation.ID;
            plan.PlanMunicipalityID = Program.Session.User.Municipality.ID;
            Program.DBContext.Plans.Add(plan);
            return plan.ID;
        }
    }
}
