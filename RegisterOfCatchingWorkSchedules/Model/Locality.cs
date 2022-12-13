using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.Model
{
	public class Locality
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual List<LocalityArea> Areas { get; set; }
	}
}
