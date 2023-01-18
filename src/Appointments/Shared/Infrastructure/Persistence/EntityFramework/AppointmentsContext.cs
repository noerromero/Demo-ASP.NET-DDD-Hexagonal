

using Appointments.Domain;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Shared.Infrastructure.Persistence.EntityFramework
{
    public class AppointmentsContext: DbContext
    {
        public AppointmentsContext(DbContextOptions<AppointmentsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}