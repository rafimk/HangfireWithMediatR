using System.ComponentModel;
using System.Data.SqlClient;
using MediatR;

namespace HangfireWithMediatR.API.Decorator;

public class MediatorHangfireBridge
{
    private readonly IMediator _mediator;

    public MediatorHangfireBridge(IMediator mediator)
    {
        _mediator = mediator;
    }

    [DisplayName("{0}")]
    public async Task Send(string jobName,IRequest request)
    {
        await _mediator.Send(request);
    }
}