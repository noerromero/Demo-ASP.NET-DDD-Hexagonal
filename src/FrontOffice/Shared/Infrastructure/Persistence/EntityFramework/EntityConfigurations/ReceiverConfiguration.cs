using FrontOffice.Calendars.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedCore.Infrastructure.Persistence.EntityFramework.Extension;

namespace FrontOffice.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations;

public class ReceiverConfiguration : IEntityTypeConfiguration<Receiver>
{
    public void Configure(EntityTypeBuilder<Receiver> builder)
    {
         builder.ToTable(nameof(FrontOfficeContext.Receivers).ToDatabaseFormat());

        //Id of table
        builder.HasKey(x => x.Id);

        //Name of fields
        builder.Property(x => x.Id).HasColumnName(nameof(Receiver.Id));
        builder.Property(x => x.ToUserId).HasColumnName(nameof(Receiver.ToUserId));
        builder.Property(x => x.AppointmentId).HasColumnName(nameof(Receiver.AppointmentId));
        
        //constrains of fields
        builder.Property(x => x.ToUserId).IsRequired();
        builder.Property(x => x.Id).ValueGeneratedNever();
    }
}