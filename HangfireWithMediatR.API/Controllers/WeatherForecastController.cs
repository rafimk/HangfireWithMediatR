using System.Data.SqlClient;
using Hangfire;
using HangfireWithMediatR.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HangfireWithMediatR.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public WeatherForecastController(IBackgroundJobClient backgroundJobClient,
                                    ILogger<WeatherForecastController> logger)
    {
        _backgroundJobClient = backgroundJobClient;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // _backgroundJobClient.Enqueue(() => Console.WriteLine("test"));
        _backgroundJobClient.Enqueue<IBacgroundJobs>(jobService => jobService.PullData());
        
        return GetWeather();

    }

    [HttpPost("schedule")]
    public async Task<ActionResult> Shedule()
    {
        var jobId = _backgroundJobClient.Schedule(() => Console.WriteLine("shcedule jobs"), TimeSpan.FromMinutes(1));
        _backgroundJobClient.ContinueJobWith(jobId, () => Console.WriteLine("shcedule jobs"));
        
        return Ok();
    }

    private IEnumerable<WeatherForecast> GetWeather()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}