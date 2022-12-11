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

		public static Plans GetPlan(int planID) // Возвращает null если нет плана с planID
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

		public static void AddPlace(int planID, Places place)
        {
			GetPlan(planID).Municipality.Places.Add(place);
		}

		public static void RemovePlace(int planID, Places place)
        {
			GetPlan(planID).Municipality.Places.Remove(place);
		}

		public static void EditPlace(int planID, Places oldPlace, Places newPlace)
		{
			var plan = GetPlan(planID);
			plan.Municipality.Places.Remove(oldPlace);
			plan.Municipality.Places.Add(newPlace);
		}

		public static void ToggleTask(int planID, Places place, DateTime date)
		{
			var plan = GetPlan(planID);
			plan.Municipality.Places.Add(place);
			plan.PlanDate = date;
		}

		public static StatusHistory[] GetStatusHistory(int planID)
		{
			return GetPlan(planID).StatusHistory.ToArray();
		}

		public static void RevertChanges(int planID)
		{

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
