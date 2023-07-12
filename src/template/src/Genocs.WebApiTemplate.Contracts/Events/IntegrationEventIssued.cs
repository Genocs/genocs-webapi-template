using Genocs.Core.CQRS.Events;

namespace Genocs.WebApiTemplate.Shared.Events;


public class IntegrationEventIssued : IEvent
{
    public string Title { get; set; }
}
