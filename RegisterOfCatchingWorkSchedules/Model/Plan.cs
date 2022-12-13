using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.Model
{
	public class Plan
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }
		
		public virtual Locality Locality { get; set; }
		
		public virtual PlanStatus Status { get; set; }

		public virtual List<AreaCatchTask> Tasks { get; set; }

		public DateTime StatusChangeDate { get; set; }

		public bool IsEditable { get; set; }
		
		public virtual List<PlanStatusChangeRecord> StatusHistory { get; set; }

		public Plan() 
		{
			Tasks = new List<AreaCatchTask>();
			StatusHistory = new List<PlanStatusChangeRecord>();
		}

		public Plan(DateTime month, Locality locality) : this()
		{
			Date = month;
			Locality = locality;
			IsEditable = true;
		}
	}
}
