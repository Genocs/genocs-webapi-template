using Genocs.Core.CQRS.Commands;

namespace Genocs.Library.Template.Contracts.Commands;

public class DemoCommand : ICommand
{
    public string Payload { get; }

    public DemoCommand(string payload) => Payload = payload;
}
