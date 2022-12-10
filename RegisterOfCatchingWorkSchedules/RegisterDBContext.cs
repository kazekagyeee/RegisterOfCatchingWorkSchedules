using System.Data.Entity;

namespace RegisterOfCatchingWorkSchedules
{
	public class RegisterDBContext : DbContext
	{
		public DbSet<Plans> Plans { get; set; }

		public DbSet<Roles> Roles { get; set; }

		public DbSet<Places> Places { get; set; }

		public DbSet<Municipality> Municipality { get; set; }

		public DbSet<Organisation> Organisation { get; set; }

		public DbSet<Users> Users { get; set; }

		public DbSet<Statuses> Statuses { get; set; }

		public DbSet<StatusHistory> StatusHistory { get; set; }

		public DbSet<RolePowers> RolePowers { get; set; }

		public DbSet<Records> Records { get; set; }
	}
}
