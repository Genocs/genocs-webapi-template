using Genocs.Core.CQRS.Commands;

namespace Genocs.Library.Template.Contracts.Commands;

public class DemoCommand(string payload) : ICommand
{
    public string Payload { get; } = payload;
}
