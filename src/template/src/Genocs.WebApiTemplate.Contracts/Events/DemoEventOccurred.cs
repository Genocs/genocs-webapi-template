using Genocs.Core.CQRS.Events;

namespace Genocs.WebApiTemplate.Shared.Events;

public class DemoEventOccurred : IEvent
{
    public string Payload { get; set; }
    public int Value { get; set; }
}
