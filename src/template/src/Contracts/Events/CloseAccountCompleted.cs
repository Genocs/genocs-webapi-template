using Genocs.Core.CQRS.Events;

namespace Genocs.Library.Template.Shared.Events
{
    public class CloseAccountCompleted : IEvent
    {
        public Guid AccountId { get; set; }
    }
}
