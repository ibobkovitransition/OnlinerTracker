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
	}
}