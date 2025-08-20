using Microsoft.Extensions.Configuration;
using Refit;
using WeatherForecast.Client;

// ReSharper disable once CheckNamespace for discoverability of service collection extensions in external client projects
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherForecastClient(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["WeatherApi:BaseUrl"]
            ?? throw new ArgumentException("WeatherApi:BaseUrl configuration value is required", nameof(configuration));

        services.AddRefitClient<IWeatherApiClient>(DefaultRefitSettings.Instance)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(baseUrl));

        return services;
    }
}
