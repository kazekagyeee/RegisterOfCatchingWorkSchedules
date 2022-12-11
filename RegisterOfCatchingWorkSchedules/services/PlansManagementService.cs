using System;
using System.Collections.Generic;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules
{
    public static class PlansManagementService
    {
        public static List<Plans> GetAllowedPlans()
        {
            using (var dbContext = new RegisterDBContext())
            {
                var user = Program.Session.User;
                if (user != null)
                {
                    var userRole = user.Roles;
                    var rolePowers = dbContext.RolePowers
                        .Where(x => x.RoleID == userRole.ID)
                        .ToList();
                    var availableStatuses = rolePowers.Select(x => x.Statuses).ToList();
                    return GetPlansWithStatuses(availableStatuses);
                }
                else
                {
                    //var availableStatuses = dbContext.Statuses.Where(x => x.StatusName == "Done").ToList();
                    //return GetPlansWithStatuses(availableStatuses);
                    var result =  dbContext.Plans.ToList();
                    result.Select(x => x.Municipality.MunicipalityName + x.Statuses.StatusName).ToArray(); //just to load the data
                    return result;
				}
            }
        }

        private static List<Plans> GetPlansWithStatuses(List<Statuses> availableStatuses)
        {
            using (var dbContext = new RegisterDBContext())
            {
                return dbContext.Plans
                    .Where(x => availableStatuses.Any(s => s.ID == x.PlanStatusID))
                    .ToList();
            }
        }

        public static void DeletePlan(int planID)
        {
            using (var dbContext = new RegisterDBContext())
            {
                var planToRemove = dbContext.Plans.FirstOrDefault(x => x.ID == planID);
                dbContext.Plans.Remove(planToRemove);
                dbContext.SaveChanges();
            }
        }

        public static Plans CreatePlan(DateTime planDate)
        {
            using (var dbContext = new RegisterDBContext())
            {
                var plan = new Plans();
                plan.Statuses = dbContext.Statuses.FirstOrDefault(x => x.StatusName == "Черновик");
                plan.PlanDate = planDate;
                plan.StatusChangeDate = DateTime.Now;
                plan.Organisation = Program.Session.User.Organisation;
                plan.Municipality = Program.Session.User.Municipality;
                dbContext.Plans.Add(plan);
                dbContext.SaveChanges();
                return plan;
            }
        }

        public static void ChangePlanProperties(Dictionary<string, object> changedValues, int planID)
        {
            using (var dbContext = new RegisterDBContext())
            {
                var changedPlan = dbContext.Plans.FirstOrDefault(x => x.ID == planID);
                var properties = typeof(Plans).GetProperties();
                foreach (var value in changedValues)
                {
                    foreach (var property in properties)
                    {
                        if (property.Name == value.Key)
                        {
                            property.SetValue(changedPlan, value.Value);
                        }
                    }
                }
                dbContext.SaveChanges();
            }
        }

        public static void RevertUnsavedChanges()
        {
            using (var dbContext = new RegisterDBContext())
            {
                dbContext.RevertUnsavedChanges();
            }
        }

        public static void SaveChanges()
        {
            using (var dbContext = new RegisterDBContext())
            {
                dbContext.SaveChanges();
            }
        }
    }
}
