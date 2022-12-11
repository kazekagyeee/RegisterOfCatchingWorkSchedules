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

		public static Plans GetPlan(int planId)
		{ 
			return null;
		}

		public static int CreatePlan(DateTime date, Municipality municipality)
		{
			return -1;
		}

		public static void SetPlanDate(int planId, DateTime date) { }

		public static void SetPlanMunicipalty(int planId, Municipality municipality) { }

		public static void SetPlanStatus(int planId, Statuses status) { }

		public static void AddPlace(int planId, Places place) { }

		public static void RemovePlace(int planId, Places place) { }

		public static void EditPlace(int planId, Places oldPlace, Places newPlace) { }

		public static void ToggleTask(int planId, Places place, DateTime day) { }

		public static StatusHistory[] GetStatusHistory(int planId) { return null; }

		public static void RevertChanges(int planId) { }

		public static void Save(int planId) { }

		public static bool TryRemovePlan(int planId) { return false; }
	}
}
