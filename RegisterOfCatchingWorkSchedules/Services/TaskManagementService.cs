using RegisterOfCatchingWorkSchedules.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.Services
{
	public static class TaskManagementService
	{
		public static void AddDailyTask(Plan plan, int areaID, int day)
		{
			//TODO: check if ara task created
			var task = plan.Tasks.Single(x => x.Area.Id == areaID);
			task.DailyTasks += 1 << day;
		}

		public static void RemoveDailyTask(Plan plan, int areaID, int day)
		{
			//TODO: check if ara task created
			var task = plan.Tasks.Single(x => x.Area.Id == areaID);
			task.DailyTasks -= 1 << day;
		}

		public static void CreateTask(Plan plan, int areaID)
		{
			var area = AppDBContext.Instance.Areas.Find(areaID);
			if (area == null)
				return;
			var task = new AreaCatchTask(plan, area, plan.Date);
			plan.Tasks.Add(task);
		}

		public static void RemoveTask(Plan plan, int areaID)
		{
			var task = plan.Tasks.FirstOrDefault(x => x.Area.Id == areaID);
			if (task != null)
				plan.Tasks.Remove(task);
		}

		public static IReadOnlyList<int> GetDailyTasks(AreaCatchTask task)
		{
			var result = new List<int>();
			for (int i = 1; i <= 31; i++)
				if ((task.DailyTasks & 1 << i) != 0)
					result.Add(i);
			return result;
		}
	}
}
