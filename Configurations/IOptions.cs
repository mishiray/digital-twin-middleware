using DigitalTwinMiddleware.DTOs;
using DigitalTwinMiddleware.DTOs.ServiceDtos;

namespace DigitalTwinMiddleware.Configurations
{
    public static class IOptions
    {
        public static IServiceCollection ConfigureAppSetting(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<JWT>(configuration.GetSection("JWT"));
        }
    }
}
