using EFCoreTestApp.Model;
using EFCoreTestApp.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EFCoreTestApp
{
	public static class StatusesController
	{
		public static BindingList<PlanStatus> GetStatusesBindingList()
		{
			AppDBContext.Instance.PlanStatuses.Load();
			return AppDBContext.Instance.PlanStatuses.Local.ToBindingList();
		}

		public static PlanStatus GetDefault() => AppDBContext.Instance.PlanStatuses.First();
	}
}
