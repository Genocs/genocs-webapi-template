using System;

namespace Genocs.WebApiTemplate.Shared.Events
{
    public class CloseAccountCompleted : Interfaces.IEvent
    {
        public Guid AccountId { get; set; }
    }
}
