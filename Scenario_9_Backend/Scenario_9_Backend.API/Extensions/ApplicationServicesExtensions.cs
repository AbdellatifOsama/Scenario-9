using Microsoft.AspNetCore.Identity;
using Scenario_9_Backend.API.Helpers;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.BLL.Repositories;
using Scenario_9_Backend.BLL.Services;
using Scenario_9_Backend.DAL.Data;
using Scenario_9_Backend.DAL.Entities;

namespace Scenario_9_Backend.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IContactRepository, ContactsRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICheckoutRepository, CheckoutRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            return services;
        }
    }
}
