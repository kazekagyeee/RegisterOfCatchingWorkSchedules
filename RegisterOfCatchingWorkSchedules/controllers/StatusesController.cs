using RegisterOfCatchingWorkSchedules.Services;
using System.ComponentModel;

namespace RegisterOfCatchingWorkSchedules.Coltrollers
{
	public static class StatusesController
	{
		public static BindingList<Statuses> GetStatusesBindingList() => StatusesService.GetBindingList();
	}
}
