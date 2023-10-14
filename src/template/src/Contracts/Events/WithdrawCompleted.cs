using Genocs.Core.CQRS.Events;

namespace Genocs.Library.Template.Shared.Events;

public class WithdrawCompleted : IEvent
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
}
