using RegisterOfCatchingWorkSchedules.Services;
using System.ComponentModel;

namespace RegisterOfCatchingWorkSchedules.Coltrollers
{
	public static class MunicipaltyController
	{
		public static Places[] GetAllPlaces() => MunicipalityService.GetAllPlaces();

		public static BindingList<Municipality> GetMunicipalitiesBindingList()
			=> MunicipalityService.GetMunicipalitiesBindingList();
	}
}
