namespace WeatherForecast.Domain;

public class WeatherService : IWeatherService
{
    public int GetAverageTemperature(string city, DateTimeOffset dateTimeOffset)
    {
        return Random.Shared.Next(-10, 40);
    }
}
