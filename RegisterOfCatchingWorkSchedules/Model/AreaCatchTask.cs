using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.Model
{
	public class AreaCatchTask
	{
		public int Id { get; set; }

		public virtual Plan Plan { get; set; }

		public virtual LocalityArea Area { get; set; }

		public DateTime Date { get; set; }

		public int DailyTasks { get; set; }

		public AreaCatchTask() { }

		public AreaCatchTask(Plan plan, LocalityArea area, DateTime date)
		{
			Plan = plan;
			Area = area;
			Date = date;
		}
	}
}
