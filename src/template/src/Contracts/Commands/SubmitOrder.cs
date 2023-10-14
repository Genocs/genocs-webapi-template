namespace Genocs.Library.Template.Contracts.Commands;

public interface SubmitOrder
{
    Guid Id { get; }
    public string OrderId { get; }
    public string UserId { get; }
}
