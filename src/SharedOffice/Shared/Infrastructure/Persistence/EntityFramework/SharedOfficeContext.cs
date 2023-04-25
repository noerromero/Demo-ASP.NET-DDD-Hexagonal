
using Microsoft.EntityFrameworkCore;
using SharedOffice.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using SharedOffice.Users.Domain;

namespace SharedOffice.Shared.Infrastructure.Persistence.EntityFramework
{
	public class SharedOfficeContext : DbContext
    {
		public SharedOfficeContext(DbContextOptions<SharedOfficeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HelperConfiguration());
            
        }

        public DbSet<Helper> Helpers { get; set; } = null!;
    }
}

