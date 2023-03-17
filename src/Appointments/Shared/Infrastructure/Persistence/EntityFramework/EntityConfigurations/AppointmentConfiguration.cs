using Appointments.Calendars.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedCore.Infrastructure.Persistence.EntityFramework.Extension;

namespace Appointments.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        //Name of table
        builder.ToTable(nameof(AppointmentsContext.Appointments).ToDatabaseFormat());

        //Id of table
        builder.HasKey(x => x.Id);

        //Name of fields
        builder.Property(x => x.Id).HasColumnName(nameof(Appointment.Id));
        builder.Property(x => x.CalendarId).HasColumnName(nameof(Appointment.CalendarId));
        builder.Property(x => x.Message).HasColumnName(nameof(Appointment.Message));
        builder.Property(x => x.FromUserId).HasColumnName(nameof(Appointment.FromUserId));
        builder.OwnsOne(x => x.RangeOfDates, x =>
        {
            x.Property(y => y.StartDateTime).IsRequired();
            x.Property(y => y.EndDateTime).IsRequired();
        });
        
        //constrains of fields
        builder.Property(x => x.CalendarId).IsRequired();
        builder.Property(x => x.FromUserId).IsRequired();
        builder.Property(x => x.Id).ValueGeneratedNever();
    }
}