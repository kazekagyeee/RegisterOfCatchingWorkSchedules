using System;
using System.Collections.Generic;

namespace RegisterOfCatchingWorkSchedules
{
	public static class PlanController
	{
		public static List<Plans> GetAllPlans() => PlansManagementService.GetAllowedPlans();

		public static Plans GetPlan(int planID) => PlansManagementService.GetById(planID);

		public static Plans CreatePlan(DateTime date) => PlansManagementService.CreatePlan(date);

		public static void SetPlanDate(int planID, DateTime date) => PlansManagementService.ChangePlanPropertiy(planID, "PlanDate", date);

		public static void SetPlanStatus(int planID, Statuses status) => PlansManagementService.SetPlanStatus(planID, status.ID);

		public static void RemovePlace(int planID, int placeID) => PlansManagementService.RemovePlace(planID, placeID);

		public static void EditPlace(int planID, int oldPlaceID, int newPlaceID) => PlansManagementService.ChangePlace(planID, oldPlaceID, newPlaceID);

		public static void AddRecord(int planID, int placeID, int day) => RecordManagementService.CreateRecord(planID, placeID, day);

		public static void RemoveRecord(int planID, int placeID, int day) => RecordManagementService.RemoveRecord(planID, placeID, day);

		public static StatusHistory[] GetStatusHistory(int planID) => StatusHistoryService.GetHistory(planID);

		public static void RemovePlan(int planID) => PlansManagementService.DeletePlan(planID);
	}
}
