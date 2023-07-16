using Genocs.Persistence.MongoDb.Repositories;
using Genocs.WebApiTemplate.Contracts.Commands;
using Genocs.WebApiTemplate.Domain.Aggregates;
using MassTransit;

namespace Genocs.WebApiTemplate.Worker.Consumers;

public class SubmitOrderConsumer : IConsumer<SubmitOrder>
{
    private readonly ILogger<SubmitOrderConsumer> _logger;

    private readonly IMongoDbRepository<Order> _orderRepository;

    public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger, IMongoDbRepository<Order> orderRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task Consume(ConsumeContext<SubmitOrder> context)
    {
        Order order = new Order(context.Message.OrderId, context.Message.UserId, "", 1, "EUR");
        await _orderRepository.InsertAsync(order);
        _logger.LogInformation($"Order {context.Message.OrderId} processed!");
    }
}