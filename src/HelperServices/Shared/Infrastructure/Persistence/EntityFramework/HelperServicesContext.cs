

using HelperServices.Calendars.Domain;
using HelperServices.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HelperServices.Shared.Infrastructure.Persistence.EntityFramework
{
    public class HelperServicesContext: DbContext
    {
        public HelperServicesContext(DbContextOptions<HelperServicesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiverConfiguration());
        }

        public DbSet<Calendar> Calendars { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Receiver> Receivers { get; set; } = null!;
    }
}