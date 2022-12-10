using System;

namespace RegisterOfCatchingWorkSchedules
{
	public static class PlanController
	{
		public static Plan[] GetAllPlans() { throw new NotImplementedException(); }

		public static Plan OpenPlan(int id) { throw new NotImplementedException(); }

		public static void CreatePlan(Plan plan) { }

		public static void SetPlanStatus(Statuses status) { }

		public static void AddLocation(Location location) { }

		public static void ToggleTask(Location location, DateTime day) { }

		public static StatusHistory[] GetStatusHistory(int planID) { throw new NotImplementedException(); }

		public static void Save() { }

		public static bool TryRemovePlan(int id) { throw new NotImplementedException(); }
	}
}
