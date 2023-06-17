using DigitalTwinMiddleware.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalTwinMiddleware.Configurations
{
    public static class ScopedServices
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services) => services
            .AddScoped<IDbTransactionService, DbTransactionService>()
            .AddScoped<IDeviceRelationshipService, DeviceRelationshipService>()
            .AddScoped<IRepository, Repository>()
            .AddScoped<IDeviceService, DeviceService>()
            .AddScoped<IUserService, UserService>();
    }
}
