using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.Model
{
	public class PlanStatusChangeRecord
	{
		public int Id { get; set; }

		public virtual Plan Plan { get; set; }

		public virtual PlanStatus Status { get; set; }

		public DateTime Date { get; set; }

		public PlanStatusChangeRecord() { }

		public PlanStatusChangeRecord(Plan plan, PlanStatus status, DateTime date)
		{
			Plan = plan;
			Status = status;
			Date = date;
		}
	}
}
