using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var configExp = new MapperConfigurationExpression();
            configExp.AddProfile<MapperProfile>();

            // Solución: Asegúrate de tener el paquete Microsoft.Extensions.Logging.Console instalado.
            // Agrega el using anterior para que AddConsole esté disponible.

            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            var mapperConfig = new MapperConfiguration(configExp, loggerFactory);

            services.AddSingleton(mapperConfig);
            services.AddSingleton<IMapper>(provider => new Mapper(mapperConfig));
            services.AddTransient<ICreateUSerCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUsercommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();

            return services;
        }
    }
}
