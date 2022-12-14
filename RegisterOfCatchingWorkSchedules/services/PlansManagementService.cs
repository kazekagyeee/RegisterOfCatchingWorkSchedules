using RegisterOfCatchingWorkSchedules.services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules
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
					.FirstOrDefault(x => x.ID == planID);
			}
		}

		public static List<Plans> GetAllowedPlans()
		{
			var plans = new List<Plans>();
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				//var user = Program.Session.User;
				//var userRole = user.Roles;
				//var rolePowers = dbContext.RolePowers
				//	.Where(x => x.RoleID == userRole.ID)
				//	.ToList();
				//var availableStatuses = rolePowers.Select(x => x.Statuses).ToList();
				//plans = GetPlansWithStatuses(availableStatuses);
				return dbContext.Plans
					.Include(x => x.Municipality)
					.Include(x => x.Statuses)
					.Include(x => x.Organisation)
					.Include(x => x.Records.Select(p => p.Places))
					.ToList();
			}
			return plans;
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
				var planToRemove = dbContext.Plans.FirstOrDefault(x => x.ID == planID);
				dbContext.Plans.Remove(planToRemove);
				dbContext.SaveChanges();
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

		public static void ChangePlanProperties(Dictionary<string, object> changedValues, int planID)
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
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
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				//dbContext.RevertUnsavedChanges();
			}
		}

		public static void SaveChanges()
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				dbContext.SaveChanges();
			}
		}
	}
}
