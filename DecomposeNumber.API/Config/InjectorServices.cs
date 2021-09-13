using DecomposeNumber.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DecomposeNumber.API.Config
{
    public static class InjectorServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<INumberService, NumberService>();
        }
    }
}