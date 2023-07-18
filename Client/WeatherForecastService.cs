using Net8BlazorWebAssembly.Shared;
using System.Net.Http.Json;

namespace Net8BlazorWebAssembly.Client;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly HttpClient httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        var forecasts = await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        return forecasts!;
    }
}
