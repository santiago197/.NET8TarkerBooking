using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(u => u.UserId);
            entityBuilder.Property(u => u.FirstName).IsRequired();
            entityBuilder.Property(u => u.LastName).IsRequired();
            entityBuilder.Property(u => u.UserName).IsRequired();
            entityBuilder.Property(u => u.Password).IsRequired();

            entityBuilder.HasMany(u => u.Bookings)
                .WithOne(x=>x.User)
                .HasForeignKey(x=>x.UserId);

        }
    }
}
