

using FrontOffice.Calendars.Domain;
using FrontOffice.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FrontOffice.Shared.Infrastructure.Persistence.EntityFramework
{
    public class FrontOfficeContext: DbContext
    {
        public FrontOfficeContext(DbContextOptions<FrontOfficeContext> options) : base(options)
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