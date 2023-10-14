using Genocs.Core.CQRS.Events;

namespace Genocs.Library.Template.Shared.Events;

public class TransferCompleted : IEvent
{
    public Guid OriginalAccountId { get; set; }
    public Guid DestinationAccountId { get; set; }
    public decimal Amount { get; set; }
}
