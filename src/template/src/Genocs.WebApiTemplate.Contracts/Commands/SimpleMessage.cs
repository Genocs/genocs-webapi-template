using Genocs.Core.CQRS.Commands;

namespace Genocs.WebApiTemplate.Shared.Commands;

public class SimpleMessage : ICommand
{
    public string MessageId { get; set; }

    public string MessageBody { get; set; }

}
