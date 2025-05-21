namespace Demanio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            return services;
        }
    }
}
