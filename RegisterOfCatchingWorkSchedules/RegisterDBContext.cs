using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
	public class RegisterDBContext : DbContext
	{
		public DbSet<Plans> Plans { get; set; }

		public DbSet<Roles> Roles { get; set; }

		public DbSet<Places> Places { get; set; }

		public DbSet<Municipality> Municipality { get; set;}
	}
}
