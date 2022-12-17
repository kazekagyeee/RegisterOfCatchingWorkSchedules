using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules.Services
{
    public static class PlansManagementService
    {
        public static Plans GetById(int planID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                return dbContext.Plans
                    .Include(x => x.Municipality)
                    .Include(x => x.Statuses)
                    .Include(x => x.Organisation)
                    .Include(x => x.Records.Select(p => p.Places))
                    .Include(x => x.StatusHistory)
                    .FirstOrDefault(x => x.ID == planID);
            }
        }

        public static List<Plans> GetAllowedPlans(Filter filter, int page)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var availableStatuses = new List<Statuses>();
                var user = Program.Session.User;
                if (user != null)
                {
                    var userRole = user.Roles;
                    var rolePowers = dbContext.RolePowers
                        .Where(x => x.RoleID == userRole.ID)
                        .ToList();
                    availableStatuses = rolePowers.Select(x => x.Statuses).ToList();
                }
                else
                {
                    availableStatuses = new List<Statuses>() { StatusesService.GetFinished() };
                }

                var plans = GetPlansWithStatuses(availableStatuses)
                    .Where(x => x.PlanDate >= filter.MinPlanDate 
                    && x.PlanDate <= filter.MaxPlanDate)
                    .Where(x => x.StatusChangeDate >= filter.MinPlanStatusChangeDate 
                    && x.StatusChangeDate <= filter.MaxPlanStatusChangeDate);
                if (filter.StatusID > 0)
                {
                    plans = plans.Where(x => x.PlanStatusID == filter.StatusID);
                }
                if (filter.MunicipalityID > 0)
                {
                    plans = plans.Where(x => x.PlanMunicipalityID == filter.MunicipalityID);
                }
                return plans.Skip(page * 10).Take(10).ToList();
            }
        }

        private static List<Plans> GetPlansWithStatuses(List<Statuses> availableStatuses)
        {
            var plansToReturn = new List<Plans>();
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var plans = dbContext.Plans
                    .Include(x => x.Municipality)
                    .Include(x => x.Statuses)
                    .Include(x => x.Organisation)
                    .Include(x => x.Records.Select(p => p.Places))
                    .Include(x => x.StatusHistory)
                    .ToList();

                foreach (var status in availableStatuses)
                {
                    var plansWithStatus = plans.Where(x => x.PlanStatusID == status.ID).ToList();
                    plansToReturn.AddRange(plansWithStatus);
                }
            }
            return plansToReturn;
        }

        public static void DeletePlan(int planID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var plan = dbContext.Plans.Where(x => x.ID == planID).FirstOrDefault();
                if (plan != null)
                {
                    var planToRemove = dbContext.Plans
                    .Include(x => x.Municipality)
                    .Include(x => x.Statuses)
                    .Include(x => x.Organisation)
                    .Include(x => x.Records.Select(p => p.Places))
                    .Include(x => x.StatusHistory)
                    .FirstOrDefault(x => x.ID == planID);
                    dbContext.Plans.Remove(planToRemove);
                    dbContext.SaveChanges();
                } else
                {
                    throw new Exception("Missing plan with this ID");
                }
            }
        }

        public static Plans CreatePlan(DateTime planDate)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var plan = new Plans();
                plan.PlanDate = planDate;
                plan.PlanMunicipalityID = Program.Session.User.Municipality.ID;
                plan.OrganisationID = Program.Session.User.Organisation.ID;
                plan.PlanStatusID = StatusesService.GetDefault().ID;
                dbContext.Plans.Add(plan);
                dbContext.SaveChanges();

                SetPlanStatus(plan.ID, StatusesService.GetDefault().ID);
                return GetById(plan.ID);
            }
        }

        public static void SetPlanStatus(int planID, int statusID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var plan = dbContext.Plans.FirstOrDefault(x => x.ID == planID);
                plan.PlanStatusID = statusID;
                plan.StatusChangeDate = DateTime.Now;
                StatusHistoryService.AddHistoryLog(statusID, planID);
                dbContext.SaveChanges();
            }
        }

        public static void ChangePlanPropertiy(int planID, string propName, object propValueD)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var changedPlan = dbContext.Plans.FirstOrDefault(x => x.ID == planID);
                var properties = typeof(Plans).GetProperties();
                foreach (var property in properties)
                {
                    if (property.Name == propName)
                    {
                        property.SetValue(changedPlan, propValueD);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        public static void RemovePlanRecords(int planID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var plan = dbContext.Plans.FirstOrDefault(x => x.ID == planID);
                plan.Records.Clear();
                dbContext.SaveChanges();
            }
        }
    }
}
