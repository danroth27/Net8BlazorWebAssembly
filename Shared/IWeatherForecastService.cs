namespace Net8BlazorWebAssembly.Shared;

public interface IWeatherForecastService
{
    Task<WeatherForecast[]> GetForecastAsync();
}
