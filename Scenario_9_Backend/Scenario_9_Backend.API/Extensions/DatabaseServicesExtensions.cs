using Microsoft.EntityFrameworkCore;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.BLL.Repositories;
using Scenario_9_Backend.DAL.Data;

namespace Scenario_9_Backend.API.Extensions
{
    public static class DatabaseServicesExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
