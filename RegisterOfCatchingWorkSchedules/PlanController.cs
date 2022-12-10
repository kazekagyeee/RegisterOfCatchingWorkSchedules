using System;

namespace RegisterOfCatchingWorkSchedules
{
	public static class PlanController
	{
		public static Plans[] GetAllPlans() { return null; }

		public static Plans GetPlan(int id) { return null; }

		public static int CreatePlan(DateTime date, int municipalityId) { return -1; }

		public static void SetPlanDate(int planId, DateTime date) { }

		public static void SetPlanMunicipalty(int planId, int municipalityId) { }

		public static void SetPlanStatus(int planId, int statusId) { }

		public static void AddLocation(int planId, int locationId) { }

		public static void ToggleTask(int planId, int locationId, DateTime day) { }

		public static StatusHistory[] GetStatusHistory(int planId) { return null; }

		public static void RevertChanges(int planId) { }

		public static void Save(int planId) { }

		public static bool TryRemovePlan(int id) { return false; }

		public static void RemoveLocation(int currentPlanId, int locationId) { }

		public static void EditLocation(int currentPlanId, int oldLocationId, int newLocationId) { }
	}
}
