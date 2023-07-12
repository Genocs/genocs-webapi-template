using Genocs.Core.Domain.Repositories;
using Genocs.WebApiTemplate.Contracts.Commands;
using Genocs.WebApiTemplate.Domain.Aggregates;
using MassTransit;
using MongoDB.Bson;

namespace Genocs.WebApiTemplate.Worker.Consumers;

public class SubmitOrderConsumer : IConsumer<SubmitOrder>
{
    private readonly ILogger<SubmitOrderConsumer> _logger;

    private readonly IRepository<Order, ObjectId> _orderRepository;

    public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger, IRepository<Order, ObjectId> orderRepository)
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