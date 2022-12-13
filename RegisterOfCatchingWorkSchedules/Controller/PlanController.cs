using RegisterOfCatchingWorkSchedules.Model;
using RegisterOfCatchingWorkSchedules.Services;
using System.Numerics;

namespace RegisterOfCatchingWorkSchedules
{
	public static class PlanController
	{
		public static Plan[] GetAll() => PlanManagementService.GetAll();

		public static Plan GetById(int planID) => PlanManagementService.GetById(planID);

		public static Plan CreatePlan(DateTime date, Locality locality) => PlanManagementService.CreatePlan(date, locality);

		public static void SetDate(Plan plan, DateTime month) => plan.Date = month;

		public static void SetLocality(Plan plan, Locality locality) => plan.Locality = locality;

		public static void SetStatus(Plan plan, PlanStatus status) => PlanManagementService.SetStatus(plan, status);

		public static void AddAreaTask(Plan plan, int areaId) => TaskManagementService.CreateTask(plan, areaId);

		public static void RemoveAreaTask(Plan plan, int areaID) => TaskManagementService.RemoveTask(plan, areaID);

		public static void ChangeArea(Plan plan, int oldAreaId, int newAreaId)
		{
			//TODO move to service
			var newArea = LocalityController.GetAreaById(newAreaId);
			foreach (var task in plan.Tasks)
				if (task.Area.Id == oldAreaId)
					task.Area = newArea;
		}

		public static void AddDailyTask(Plan plan, int areaID, int day) => TaskManagementService.AddDailyTask(plan, areaID, day);

		public static void RemoveDailyTask(Plan plan, int areaID, int day) => TaskManagementService.RemoveDailyTask(plan, areaID, day);

		public static IReadOnlyList<PlanStatusChangeRecord> GetStatusHistory(Plan plan) => plan.StatusHistory;

		public static void RevertChanges(Plan plan) => PlanManagementService.RevertChanges(plan);

		public static void Remove(Plan plan) => PlanManagementService.RemovePlan(plan);
	}
}
