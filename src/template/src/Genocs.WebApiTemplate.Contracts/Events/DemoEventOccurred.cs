using Genocs.Core.CQRS.Events;

namespace Genocs.Library.Template.Shared.Events;

public class DemoEventOccurred : IEvent
{
    public string Payload { get; set; }
    public int Value { get; set; }
}
