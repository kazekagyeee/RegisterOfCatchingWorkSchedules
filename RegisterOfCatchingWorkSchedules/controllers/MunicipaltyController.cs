using RegisterOfCatchingWorkSchedules.services;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules
{
	public static class MunicipaltyController
	{
		public static Municipality[] GetAllMunicipalties() => MunicipalityService.GetAllMunicipalties();

		public static Places[] GetAllPlaces() => MunicipalityService.GetAllPlaces();

		public static BindingList<Municipality> GetMunicipalitiesBindingList() 
			=> MunicipalityService.GetMunicipalitiesBindingList();

		public static BindingList<Places> GetPlacesBindingList() => MunicipalityService.GetPlacesBindingList();
	}
}
