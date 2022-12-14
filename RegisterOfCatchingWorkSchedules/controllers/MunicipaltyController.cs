using RegisterOfCatchingWorkSchedules.services;
using System.ComponentModel;

namespace RegisterOfCatchingWorkSchedules
{
	public static class MunicipaltyController
	{
		public static Places[] GetAllPlaces() => MunicipalityService.GetAllPlaces();

		public static BindingList<Municipality> GetMunicipalitiesBindingList()
			=> MunicipalityService.GetMunicipalitiesBindingList();
	}
}
