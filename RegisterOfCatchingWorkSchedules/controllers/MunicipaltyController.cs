using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules
{
	public static class MunicipaltyController
	{
		public static Municipality[] GetAllMunicipalties() => Program.DBContext.Municipality.ToArray();

		public static Places[] GetAllPlaces() => Program.DBContext.Places.ToArray();

		public static BindingList<Municipality> GetMunicipalitiesBindingList()
		{
			Program.DBContext.Municipality.Load();
			return Program.DBContext.Municipality.Local.ToBindingList();
		}

		public static BindingList<Places> GetPlacesBindingList()
		{
			Program.DBContext.Places.Load();
			return Program.DBContext.Places.Local.ToBindingList();
		}
	}
}
