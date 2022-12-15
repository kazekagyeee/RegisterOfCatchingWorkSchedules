using RegisterOfCatchingWorkSchedules.Model;

namespace RegisterOfCatchingWorkSchedules.Controller
{
	public static class TaskController
	{
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