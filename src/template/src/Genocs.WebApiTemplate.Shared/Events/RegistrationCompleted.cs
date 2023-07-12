using System;

namespace Genocs.WebApiTemplate.Shared.Events
{
    public class RegistrationCompleted : Interfaces.IEvent
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public Guid CreditId { get; set; }
    }
}
