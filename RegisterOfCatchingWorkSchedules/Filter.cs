using System;

namespace RegisterOfCatchingWorkSchedules
{
	public class Filter
	{
		public DateTime MinPlanDate { get; set; }
		public DateTime MaxPlanDate { get; set;}

		public int StatusID { get; set; }

		public int MunicipalityID { get; set; }

		public DateTime MinPlanStatusChangeDate { get; set; }
		public DateTime MaxPlanStatusChangeDate { get; set; }
	}
}