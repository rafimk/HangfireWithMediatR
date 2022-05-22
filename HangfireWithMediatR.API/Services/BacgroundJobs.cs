using HangfireWithMediatR.API.Services.Interfaces;

namespace HangfireWithMediatR.API.Services;

public class BacgroundJobs : IBacgroundJobs
{
    private ILogger<BacgroundJobs> _logger;

    public BacgroundJobs(ILogger<BacgroundJobs> logger)
    {
        _logger = logger;
    }

    public void PullData()
    {
        _logger.LogInformation("Background job called");
    }
}