﻿using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules.services
{
    public static class MunicipalityService
    {
        public static Municipality[] GetAllMunicipalties()
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                return dbContext.Municipality.ToArray();
            }
        }

        public static Places GetPlaceByID(int id)
        {
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
                return dbContext.Places.FirstOrDefault(x => x.ID == id);
			}
		}

        public static Places[] GetAllPlaces() 
        { 
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                return dbContext.Places.ToArray();
            }
        }

        public static BindingList<Municipality> GetMunicipalitiesBindingList()
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                dbContext.Municipality.Load();
                return dbContext.Municipality.Local.ToBindingList();
            }
        }

        public static BindingList<Places> GetPlacesBindingList()
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                dbContext.Places.Load();
                return dbContext.Places.Local.ToBindingList();
            }
        }
    }
}
