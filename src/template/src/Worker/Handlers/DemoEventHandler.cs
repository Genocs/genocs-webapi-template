using Genocs.Core.CQRS.Events;
using Genocs.Library.Template.Contracts.Events;

namespace Genocs.Library.Template.Worker.Handlers;

public class DemoEventHandler : IEventHandler<DemoEvent>
{
    private readonly ILogger<DemoEventHandler> _logger;

    public DemoEventHandler(ILogger<DemoEventHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(DemoEvent @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"DemoEvent '{@event.Name}' processed!");

        // Do something with the message here
        return Task.CompletedTask;
    }
}