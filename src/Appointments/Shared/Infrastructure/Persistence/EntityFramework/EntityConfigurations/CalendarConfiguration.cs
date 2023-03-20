using Microsoft.EntityFrameworkCore;
using Appointments.Calendars.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedCore.Infrastructure.Persistence.EntityFramework.Extension;

namespace Appointments.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;

public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        //Name of table
        builder.ToTable(nameof(AppointmentsContext.Calendars).ToDatabaseFormat());

        //Id of table
        builder.HasKey(x => x.Id);

        //Name of fields
        builder.Property(x => x.Id).HasColumnName(nameof(Calendar.Id));
        builder.Property(x => x.UserId).HasColumnName(nameof(Calendar.UserId));
        builder.Property(x => x.Name).HasColumnName(nameof(Calendar.Name));
        
        //constrains of fields
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Name).IsRequired();

        
    }
}