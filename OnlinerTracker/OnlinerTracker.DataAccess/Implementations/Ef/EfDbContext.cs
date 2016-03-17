using System.Data.Entity.ModelConfiguration.Conventions;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	using System.Data.Entity;

	public class EfDbContext : DbContext
	{
		public EfDbContext(string connectionName)
			: base($"name={connectionName}")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public virtual DbSet<User> Users { get; set; }
	}
}