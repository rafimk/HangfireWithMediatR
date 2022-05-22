using Hangfire;
using HangfireWithMediatR.API.Decorator;
using MediatR;

namespace HangfireWithMediatR.API.Extensions;

public static class MediatorExtensions
{
    public static void Enqueue(this IMediator mediator, string jobName, IRequest request)
    {
        var backgroundJobClient = new BackgroundJobClient();
        backgroundJobClient.Enqueue<MediatorHangfireBridge>(x => x.Send(jobName, request));
    }
    
}