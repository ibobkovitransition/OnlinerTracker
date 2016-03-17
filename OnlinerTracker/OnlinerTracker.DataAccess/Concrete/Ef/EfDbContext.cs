using System.Data.Entity.ModelConfiguration.Conventions;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Concrete.Ef
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class EfDbContext : DbContext
	{
		public EfDbContext(string connectionName)
			: base($"name={connectionName}")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}

		public virtual DbSet<User> Users { get; set; }
	}
}