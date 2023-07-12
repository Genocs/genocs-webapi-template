using Genocs.Core.CQRS.Events;

namespace Genocs.WebApiTemplate.Shared.Events;

public class RegistrationCompleted : IEvent
{
    public Guid CustomerId { get; set; }
    public Guid AccountId { get; set; }
    public Guid CreditId { get; set; }
}
