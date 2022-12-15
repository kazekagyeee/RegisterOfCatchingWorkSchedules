using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules.Services
{
    public static class MunicipalityService
    {
		public static Places[] GetMunicipaltyPlaces(int municipalityID)
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
                return dbContext.Places.Where(x => x.MunicipalityID == municipalityID).ToArray();
			}
		}
	}
}
