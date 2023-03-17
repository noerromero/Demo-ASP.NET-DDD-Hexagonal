

using Appointments.Calendars.Domain;
using Appointments.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Shared.Infrastructure.Persistence.EntityFramework
{
    public class AppointmentsContext: DbContext
    {
        public AppointmentsContext(DbContextOptions<AppointmentsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        }

        public DbSet<Calendar> Calendars { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
    }
}