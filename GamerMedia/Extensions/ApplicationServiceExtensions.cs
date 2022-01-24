using GamerMedia.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace GamerMedia.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("gamerMediaDB"));
            });

            return services;
        }
    }
}
