using DigitalTwinMiddleware.Data;
using Microsoft.EntityFrameworkCore;

namespace DigitalTwinMiddleware.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            return
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
        }
    }
}
