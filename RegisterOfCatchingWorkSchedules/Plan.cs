using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public class Plan
    {
        public Organisation Organisation { get; set; }
        public PlanStatus Status { get; set; }
        public string Name { get; set; }
    }
}
