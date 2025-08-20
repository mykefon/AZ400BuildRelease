# WeatherForecast Build & Release

This repository is a sample .NET solution that demonstrates building and releasing a minimal weather forecast service. It contains a small ASP.NET Core web API, a domain library, a Refit-based client, unit tests, and an Azure Pipelines configuration for CI/CD.

## Repository Structure

- **WeatherForecast.Api** – ASP.NET Core web API that exposes weather data endpoints. It registers the `WeatherService` and uses controllers with Swagger enabled for development.
- **WeatherForecast.Domain** – Domain library that defines `IWeatherService` and its default `WeatherService` implementation which generates random temperatures.
- **WeatherForecast.Api.Dto** – Data transfer objects used by the API and clients.
- **WeatherForecast.Client** – Refit-based client library for consuming the API, including DI extensions for easy registration.
- **WeatherForecast.Client.UnitTest** – xUnit tests that spin up the API in memory and verify the client.
- **WeatherForecast.Deployment** – Project and pipeline files for deploying the application.
- **azure-pipelines.yml** – Azure Pipelines configuration that restores, builds, and tests the solution.

## Prerequisites

- [.NET SDK 7.0](https://dotnet.microsoft.com/download) or later
- Optional: [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli) for deployment scenarios

## Getting Started

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd AZ400BuildRelease
   ```
2. Restore packages and build the solution:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Run the automated tests:
   ```bash
   dotnet test
   ```

## Running the Web API

To run the web API locally:

```bash
dotnet run --project WeatherForecast.Api
```

The API listens on `https://localhost:5001` by default. You can test the endpoint by visiting `https://localhost:5001/api/weatherforecast` in a browser or using a tool like `curl`.

When running in development, Swagger UI is available at `https://localhost:5001/swagger` for interactive exploration.

## Client Library

Consumers can use the client library to call the API via Refit:

```csharp
services.AddWeatherForecastClient();
```

This registers an `IWeatherApiClient` that targets the local API address and returns `WeatherForecastDto` objects.

## Deployment

The `azure-pipelines.yml` file defines a pipeline that restores dependencies, builds the solution, packages the web application, and runs tests on each push to the `main` branch.

## Contributing

Feel free to open issues or submit pull requests for improvements.

## License

This project is licensed under the MIT License.
