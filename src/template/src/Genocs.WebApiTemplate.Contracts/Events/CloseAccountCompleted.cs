using Genocs.Core.CQRS.Events;

namespace Genocs.WebApiTemplate.Shared.Events
{
    public class CloseAccountCompleted : IEvent
    {
        public Guid AccountId { get; set; }
    }
}
