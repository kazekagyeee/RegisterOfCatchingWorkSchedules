using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
	public static class MunicipaltyController
	{
		public static Municipality[] GetAll() => Program.DBContext.Municipality.ToArray();

		public static Municipality GetByIndex(int index) => Program.DBContext.Municipality.ToArray()[index];

		public static string[] GetAllNames() => GetAll().Select(x => x.MunicipalityName).ToArray();

		//public static 
	}
}
