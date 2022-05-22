using System.Data;
using HangfireWithMediatR.API.Services.Interfaces;

namespace HangfireWithMediatR.API.Services;

public class TimeService : ITimeService
{
    private readonly ILogger<TimeService> _logger;

    public TimeService(ILogger<TimeService> logger)
    {
        _logger = logger;
    }

    public void PrintNow()
    {
        _logger.LogInformation(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
    }
}