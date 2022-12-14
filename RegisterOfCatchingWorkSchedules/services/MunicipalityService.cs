using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules.Services
{
    public static class MunicipalityService
    {
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
    }
}
