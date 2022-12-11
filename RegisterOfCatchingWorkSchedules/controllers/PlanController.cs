using System;
using System.Linq;
using System.Collections.Generic;

namespace RegisterOfCatchingWorkSchedules
{
	public static class PlanController
	{
		public static List<Plans> GetAllPlans()
		{
			return PlansManagementService.GetAllowedPlans();
		}

		public static Plans GetPlan(int planID)
		{
			var allPlans = GetAllPlans();
			foreach (var plan in allPlans)
				if (plan.ID == planID) return plan;
			return null;
		}

		public static Plans CreatePlan(DateTime date, Municipality municipality)
		{
			return PlansManagementService.CreatePlan(date);
		}

		public static void SetPlanDate(int planID, DateTime date)
		{
			GetPlan(planID).PlanDate = date;
		}

		public static void SetPlanMunicipalty(int planID, Municipality municipality)
		{
			GetPlan(planID).Municipality = municipality;
		}

		public static void SetPlanStatus(int planID, Statuses status)
		{
			GetPlan(planID).Statuses = status;
		}

		public static void RemovePlace(int planID, Places place)
		{
			foreach (var record in GetPlan(planID).Records)
				if (record.Places == place) record.Places = null;
		}

		public static void EditPlace(int planID, Places oldPlace, Places newPlace)
		{
			foreach (var record in GetPlan(planID).Records)
				if (record.Places == oldPlace)
					record.Places = newPlace;
		}

		public static void AddRecord(int planID, Places place, int day)
		{
			var plan = GetPlan(planID);
			RecordManagementService.CreateRecord(
				place.ID,
				planID,
				new DateTime(plan.PlanDate.Value.Year,
								plan.PlanDate.Value.Month,
									day));
		}

		public static void DeleteRecord(int planID, Places place, int day)
		{
			foreach (var record in GetPlan(planID).Records)
				if (record.Places == place && record.RecordDate.Value.Day == day)
					RecordManagementService.DeleteRecord(record.ID);
		}

		public static StatusHistory[] GetStatusHistory(int planID)
		{
			return GetPlan(planID).StatusHistory.ToArray();
		}

		public static void RevertChanges(int planID)
		{
			var plan = GetPlan(planID);
		}

		public static void Save(int planID)
		{
			PlansManagementService.SaveChanges();
		}

		public static bool TryRemovePlan(int planID)
		{
			PlansManagementService.DeletePlan(planID);
			return true;
		}
	}
}
