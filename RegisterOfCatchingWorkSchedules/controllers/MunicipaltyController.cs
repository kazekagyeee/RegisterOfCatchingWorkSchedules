using RegisterOfCatchingWorkSchedules.Services;

namespace RegisterOfCatchingWorkSchedules.Coltrollers
{
	public static class MunicipaltyController
	{
		public static Places[] GetMunicipaltyPlaces(int municipalityID) => MunicipalityService.GetMunicipaltyPlaces(municipalityID);
	}
}
