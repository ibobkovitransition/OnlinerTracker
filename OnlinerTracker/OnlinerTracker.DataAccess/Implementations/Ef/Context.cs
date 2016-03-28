using System.Data.Entity.ModelConfiguration.Conventions;
using OnlinerTracker.DataAccess.Enteties;
using System.Data.Entity;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class Context : DbContext
	{
		public Context(string connectionName)
			: base($"name={connectionName}")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public virtual DbSet<User> Users { get; set; }

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<ProductTracking> TrackedProducts { get; set; }

		public virtual DbSet<UserSettings> UserSettings { get; set; }

		public virtual DbSet<ProductPriceHistory> ProductPriceHistory { get; set; }
	}
}