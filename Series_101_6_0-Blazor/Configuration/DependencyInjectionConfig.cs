using Series_101_6_0_Blazor.Data;

namespace Series_101_6_0_Blazor.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection AddWheatherForecastServices(this IServiceCollection services)
        {
            services.AddTransient<WeatherForecastService>();
            return services;
        }

    }
}
