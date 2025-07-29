using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Customer;


namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {

        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
        {
            entityBuilder.HasKey(c => c.CustomerId);
            entityBuilder.Property(c => c.FullName).IsRequired();
            entityBuilder.Property(c => c.DocumentNumber).IsRequired();


            entityBuilder.HasMany(x => x.Bookings)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId);
        }
    }
}
