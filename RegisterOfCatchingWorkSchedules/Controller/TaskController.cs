using RegisterOfCatchingWorkSchedules.Model;
using RegisterOfCatchingWorkSchedules.Services;

namespace RegisterOfCatchingWorkSchedules.Controller
{
	public static class TaskController
	{
		public static IReadOnlyList<int> GetDailyTasks(AreaCatchTask task) => TaskManagementService.GetDailyTasks(task);
	}
}