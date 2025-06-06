using System.Text.Json.Serialization;
using Web.Factories;

namespace Demanio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddControllers()
                
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.InvalidModelStateResponseFactory = (context) =>
                    {
                        return new BadRequestResultFactory(context);
                    };
                });
            return services;
        }
    }
}
