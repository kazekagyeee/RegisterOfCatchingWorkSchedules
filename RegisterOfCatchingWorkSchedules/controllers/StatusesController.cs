using RegisterOfCatchingWorkSchedules.services;
using System.ComponentModel;
using System.Data.Entity;

namespace RegisterOfCatchingWorkSchedules
{
	public static class StatusesController
	{
		public static BindingList<Statuses> GetStatusesBindingList()
		{
			return StatusesService.GetBindingList();
		}
	}
}
