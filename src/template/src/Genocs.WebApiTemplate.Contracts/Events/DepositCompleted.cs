using Genocs.Core.CQRS.Events;

namespace Genocs.WebApiTemplate.Shared.Events;

public class DepositCompleted : IEvent
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
}
