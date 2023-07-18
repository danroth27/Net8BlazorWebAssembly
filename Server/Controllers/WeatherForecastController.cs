using Microsoft.AspNetCore.Mvc;
using Net8BlazorWebAssembly.Shared;

namespace Net8BlazorWebAssembly.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService forecastService;

    public WeatherForecastController(IWeatherForecastService forecastService)
    {
        this.forecastService = forecastService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var forecasts = await forecastService.GetForecastAsync();
        return forecasts;
    }
}
