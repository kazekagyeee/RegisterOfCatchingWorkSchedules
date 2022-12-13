using RegisterOfCatchingWorkSchedules.Model;
using Microsoft.EntityFrameworkCore;

namespace RegisterOfCatchingWorkSchedules.Services
{
	public class AppDBContext : DbContext
	{
		public static AppDBContext Instance;

		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<PlanStatus> PlanStatuses { get; set; }

		public DbSet<PlanStatusChangeRecord> PlanStatusChangeRecords { get; set; }

		public DbSet<Plan> Plans { get; set; }

		public DbSet<Organization> Organizations { get; set; }

		public DbSet<LocalityArea> Areas { get; set; }

		public DbSet<Locality> Localities { get; set; }

		public DbSet<AreaCatchTask> AreaCatchTasks { get; set; }

		public AppDBContext()
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated();
			Instance = this;
		}

		public void RevertUnsavedChanges<T>(T entity) where T : class
		{
			var entry = Entry(entity);
			if (entry == null)
				return;
			switch (entry.State)
			{
				case EntityState.Modified:
					entry.State = EntityState.Unchanged;
					break;
				case EntityState.Deleted:
					entry.Reload();
					break;
				case EntityState.Added:
					entry.State = EntityState.Detached;
					break;
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=database.db");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
