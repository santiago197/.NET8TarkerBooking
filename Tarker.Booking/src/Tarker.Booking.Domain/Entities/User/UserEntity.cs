

using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Domain.Entities.User
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<BookingEntity> Bookings { get; set; }

    }
}
