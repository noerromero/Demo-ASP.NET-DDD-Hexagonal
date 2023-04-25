
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedOffice.Users.Domain;
using SharedCore.Infrastructure.Persistence.EntityFramework.Extension;

namespace SharedOffice.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
	public class HelperConfiguration : IEntityTypeConfiguration<Helper>
	{
        public void Configure(EntityTypeBuilder<Helper> builder)
        {
            //Name of table
            builder.ToTable(nameof(SharedOfficeContext.Helpers).ToDatabaseFormat());

            //Id of table
            builder.HasKey(x => x.Id);

            //Name of fields
            builder.Property(x => x.Id).HasColumnName(nameof(User.Id));
            builder.Property(x => x.FirstName).HasColumnName(nameof(User.FirstName));
            builder.Property(x => x.LastName).HasColumnName(nameof(User.LastName));
            builder.Property(x => x.PhoneNumber).HasColumnName(nameof(User.PhoneNumber));
            builder.Property(x => x.Email).HasColumnName(nameof(User.Email));
            builder.Property(x => x.PicturePath).HasColumnName(nameof(User.PicturePath));
            builder.Property(x => x.PicturePath).HasColumnName(nameof(User.PicturePath));


            //constrains of fields
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Id).ValueGeneratedNever();

        }
    }
}

