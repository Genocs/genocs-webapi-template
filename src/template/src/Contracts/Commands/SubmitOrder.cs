namespace Genocs.Library.Template.Contracts.Commands;

public class SubmitOrder
{
    private Guid Id { get; } = Guid.NewGuid();

    public string? OrderId { get; }
    public string? UserId { get; }

}
