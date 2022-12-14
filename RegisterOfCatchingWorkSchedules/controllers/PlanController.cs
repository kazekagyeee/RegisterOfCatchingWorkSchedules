using System;
using System.Linq;
using System.Collections.Generic;
using RegisterOfCatchingWorkSchedules.services;

namespace RegisterOfCatchingWorkSchedules
{
	public static class PlanController
	{
		public static List<Plans> GetAllPlans() => PlansManagementService.GetAllowedPlans();

		public static Plans GetPlan(int planID) => PlansManagementService.GetById(planID);

		public static Plans CreatePlan(DateTime date) => PlansManagementService.CreatePlan(date);

		public static void SetPlanDate(int planID, DateTime date) => GetPlan(planID).PlanDate = date;

		public static void SetPlanMunicipalty(int planID, Municipality municipality) => GetPlan(planID).Municipality = municipality;

		public static void SetPlanStatus(int planID, Statuses status) => PlansManagementService.SetPlanStatus(planID, status.ID);

		public static void RemovePlace(int planID, int placeID)
		{
			foreach (var record in GetPlan(planID).Records)
				if (record.Places.ID == placeID) record.Places = null;
		}

		public static void EditPlace(int planID, int oldPlaceID, int newPlaceID)
		{
			foreach (var record in GetPlan(planID).Records)
				if (record.Places == MunicipalityService.GetPlaceByID(oldPlaceID))
					record.Places = MunicipalityService.GetPlaceByID(newPlaceID);
		}

		public static void AddRecord(int planID, int placeID, int day)
		{
			var planDate = GetPlan(planID).PlanDate.Value;
			RecordManagementService.CreateRecord(
				placeID,
				planID,
				new DateTime(planDate.Year, planDate.Month, day));
		}

		public static void RemoveRecord(int planID, int placeID, int day)
		{
			foreach (var record in GetPlan(planID).Records)
				if (record.Places == MunicipalityService.GetPlaceByID(placeID) && record.RecordDate.Value.Day == day)
					RecordManagementService.DeleteRecord(record.ID);
		}

		public static StatusHistory[] GetStatusHistory(int planID) => GetPlan(planID).StatusHistory.ToArray();

		public static void RemovePlan(int planID) => PlansManagementService.DeletePlan(planID);
	}
}
