using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace WeatherForecast.Client.UnitTest;

public class ServiceCollectionExtensionsTest
{
    [Fact]
    public void AddsClientUsingBaseUrlFromConfiguration()
    {
        var configValues = new Dictionary<string, string?>
        {
            ["WeatherApi:BaseUrl"] = "https://api.example.com"
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configValues)
            .Build();

        var services = new ServiceCollection();
        services.AddWeatherForecastClient(configuration);

        var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IHttpClientFactory>();
        var client = factory.CreateClient(nameof(IWeatherApiClient));

        Assert.Equal("https://api.example.com/", client.BaseAddress!.ToString());
    }
}

