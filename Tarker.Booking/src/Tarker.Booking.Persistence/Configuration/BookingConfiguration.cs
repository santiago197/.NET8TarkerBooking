using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder)
        {
            entityBuilder.HasKey(b => b.BookingId);
            entityBuilder.Property(b => b.RegisterDate).IsRequired();
            entityBuilder.Property(b => b.Code).IsRequired().HasMaxLength(50);
            entityBuilder.Property(b => b.Type).IsRequired().HasConversion<string>();
            entityBuilder.Property(b => b.CustomerId).IsRequired();
            entityBuilder.Property(b => b.UserId).IsRequired();


            entityBuilder.HasOne(x => x.User)
               .WithMany(x=>x.Bookings)
               .HasForeignKey(x => x.UserId);

            entityBuilder.HasOne(x => x.Customer)
              .WithMany(x => x.Bookings)
              .HasForeignKey(x => x.CustomerId);
        }
    }
}
