
namespace Tarker.Booking.Application.Database.User.Commands.CreateUser
{
    public interface ICreateUSerCommand
    {
        Task<CreateUserModel> Execute(CreateUserModel model);
    }
}
