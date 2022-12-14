using RegisterOfCatchingWorkSchedules.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.Services
{
	public static class PlanManagementService
	{
		public static Plan CreatePlan(DateTime date, Locality locality)
		{
			var plan = new Plan(date, locality);
			AppDBContext.Instance.Plans.Add(plan);
			SetStatus(plan, StatusesController.GetDefault());
			return plan;
		}

		public static void RemovePlan(Plan plan)
		{
			if (plan != null)
				AppDBContext.Instance.Plans.Remove(plan);
		}

		public static Plan[] GetAll()
		{
			var local = AppDBContext.Instance.Plans.Local.Where(x => x.Id == 0).ToArray();
			var result = AppDBContext.Instance.Plans.ToList();
			result.AddRange(local);
			return result.ToArray();
		}

		public static Plan GetById(int planID) => AppDBContext.Instance.Plans.Find(planID);

		public static void RevertChanges(Plan plan) => AppDBContext.Instance.RevertUnsavedChanges(plan);

		public static void SetStatus(Plan plan, PlanStatus status)
		{
			var date = DateTime.Now;
			var statusRecord = new PlanStatusChangeRecord(plan, status, SessionService.CurrentUser, date);
			plan.Status = status;
			plan.StatusHistory.Add(statusRecord);
			plan.StatusChangeDate = date;
		}
	}
}
