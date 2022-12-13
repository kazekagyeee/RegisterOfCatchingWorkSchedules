using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.Model
{
	public class Organization
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsLocalGovernment { get; set; }
	}
}
