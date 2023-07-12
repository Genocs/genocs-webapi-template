using System;

namespace Genocs.WebApiTemplate.Shared.Events
{
    public class WithdrawCompleted : Interfaces.IEvent
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
