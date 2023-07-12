namespace Genocs.WebApiTemplate.Shared.Events
{
    using Interfaces;

    public class IntegrationEventIssued : IIntegrationEvent
    {
        public string Title { get; set; }
    }
}
