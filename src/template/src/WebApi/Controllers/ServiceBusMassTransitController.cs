﻿using Genocs.Library.Template.Contracts.Commands;
using Genocs.Library.Template.WebApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Genocs.Library.Template.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceBusMassTransitController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    private readonly ILogger<ServiceBusMassTransitController> _logger;

    public ServiceBusMassTransitController(ILogger<ServiceBusMassTransitController> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
    }

    [HttpPost("SubmitOrder")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> PostSubmitOrder()
    {
        // Publish an event with MassTransit
        await _publishEndpoint.Publish<SubmitOrder>(new
        {
            OrderId = Guid.NewGuid().ToString(),
            UserId = Guid.NewGuid().ToString()
        });

        _logger.LogInformation("SubmitOrder Sent");

        return Accepted("Sent");
    }

    [HttpPost("OrderSubmitted")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> PostOrderSubmitted()
    {
        // Publish an event with MassTransit
        await _publishEndpoint.Publish<OrderSubmitted>(new
        {
            MerchantId = "0988656",
            OldStatus = "Approved",
            Status = "Rejected"
        });

        _logger.LogInformation("OrderSubmitted Sent");

        return Accepted("Sent");
    }

    //[HttpPost("SubmitOrder")]
    //public async Task<IActionResult> PostSubmitOrder()
    //{
    //    await _publishEndpoint.Publish<SubmitOrder>(new
    //    {
    //        OrderId = Guid.NewGuid().ToString(),
    //        UserId = "userId"
    //    });

    //    //await _publishEndpoint.Publish<OrderTransactionSubmittedEvent>(new
    //    //{
    //    //    OrderId = Guid.NewGuid().ToString(),
    //    //    CorrelationId = guid,
    //    //    Credit = 100m,
    //    //    CustomerId = 123456
    //    //});

    //    //List<Product> prod = new List<Product>();
    //    //prod.Add(new Product { count = 1, price = 100.11m });
    //    //prod.Add(new Product { count = 2, price = 50m});
    //    //prod.Add(new Product { count = 3, price = 1.11m });

    //    //Mutex mutex = new Mutex(Guid.NewGuid().ToString());
    //    //var d = new Dictionary<string, object>
    //    //{
    //    //    { "test" , "1233546" },
    //    //    { "test1" , 456 },
    //    //    { "basket" , prod }
    //    //};

    //    //mutex.Data = d;
    //    //mutex.Process = "dsfasfsd";

    //    //var r = _mutexRepository.InsertOne(mutex);

    //    //_mutexRepository.ReplaceOne(updateFilter, mutex);

    //    //await _azureServiceBusTopic.PublishAsync(new DemoEvent("demo event 1 subscription", "address"), filters);

    //    //// Publish an event with MassTransit
    //    //await _publishEndpoint.Publish<MerchantStatusChangedEvent>(new
    //    //{
    //    //    MerchantId = "0988656",
    //    //    OldStatus = "Approved",
    //    //    Status = "Rejected"
    //    //});

    //    return Ok("Sent");
    //}
}
