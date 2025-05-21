using Application.Abstractions.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using SoapCore;

namespace Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSoapCore();
            services.AddScoped<IDemanioService, DemanioService>();
            services.AddScoped<ISoapService, SoapService>();

            return services;
        }
    }
}
