using Genocs.Core.CQRS.Commands;

namespace Genocs.Library.Template.Shared.Commands;

public class SimpleMessage : ICommand
{
    public string MessageId { get; set; }

    public string MessageBody { get; set; }

}
