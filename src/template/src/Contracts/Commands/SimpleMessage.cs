using Genocs.Core.CQRS.Commands;

namespace Genocs.Library.Template.Shared.Commands;

public class SimpleMessage : ICommand
{
    /// <summary>
    /// The Message Id.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary>
    /// The Message Body.
    /// </summary>
    public string? MessageBody { get; set; }

}
