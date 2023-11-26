using Genocs.Core.CQRS.Events;

namespace Genocs.Library.Template.Shared.Events;

public class IntegrationEventIssued : IEvent
{
    public string? Title { get; set; }
}
