using Hangfire;
using Newtonsoft.Json;

namespace HangfireWithMediatR.API.Extensions;

public static class HangfireConfigurationExtensions
{
    public static void UseMediatR(this IGlobalConfiguration configuration)
    {
        var jsonSeetings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        configuration.UseSerializerSettings(jsonSeetings);
    }
}