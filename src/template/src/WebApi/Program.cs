using Genocs.Core.Builders;
using Genocs.Core.CQRS.Commands;
using Genocs.Core.CQRS.Events;
using Genocs.Core.CQRS.Queries;
using Genocs.Discovery.Consul;
using Genocs.HTTP;
using Genocs.Library.Template.WebApi;
using Genocs.Library.Template.WebApi.Infrastructure.Extensions;
using Genocs.LoadBalancing.Fabio;
using Genocs.Logging;
using Genocs.MessageBrokers.Outbox;
using Genocs.MessageBrokers.Outbox.MongoDB;
using Genocs.MessageBrokers.RabbitMQ;
using Genocs.Metrics.Prometheus;
using Genocs.Tracing;
using Genocs.Persistence.MongoDb.Extensions;
using Genocs.Persistence.Redis;
using Genocs.Secrets.Vault;
using Genocs.WebApi;
using Genocs.WebApi.Security;
using Genocs.WebApi.Swagger;
using Genocs.WebApi.Swagger.Docs;
using Serilog;

// using System.Reflection;

StaticLogger.EnsureInitialized();

var builder = WebApplication.CreateBuilder(args);

builder.Host
        .UseLogging()
        .UseVault();

var gnxBuilder = builder
                        .AddGenocs()
                        .AddOpenTelemetry();

gnxBuilder
        .AddErrorHandler<ExceptionToResponseMapper>()
        .AddServices()
        .AddHttpClient()
        .AddCorrelationContextLogging()
        .AddConsul()
        .AddFabio()
        .AddMongo()

        // .AddMongoFast()
        // .AddMongoRepository<Product, Guid>("products")
        // .RegisterMongoRepositories(Assembly.GetExecutingAssembly())
        .AddCommandHandlers()
        .AddEventHandlers()
        .AddQueryHandlers()
        .AddInMemoryCommandDispatcher()
        .AddInMemoryEventDispatcher()
        .AddInMemoryQueryDispatcher()
        .AddPrometheus()
        .AddRedis();

await gnxBuilder.AddRabbitMQAsync();

gnxBuilder.AddMessageOutbox(o => o.AddMongo())
        .AddWebApi()
        .AddSwaggerDocs()
        .AddWebApiSwaggerDocs()
        .Build();

var services = builder.Services;

// START: TO be Refactory

//services.AddCors();
//services.AddControllers().AddJsonOptions(x =>
//{
//    // serialize Enums as strings in api responses (e.g. Role)
//    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//});

//services.Configure<HealthCheckPublisherOptions>(options =>
//{
//    options.Delay = TimeSpan.FromSeconds(2);
//    options.Predicate = check => check.Tags.Contains("ready");
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//services.AddEndpointsApiExplorer();
//services.AddSwaggerGen();

// Add Masstransit bus configuration
services.AddCustomMassTransit(builder.Configuration);

// services.AddOptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// END: TO be Refactory

app.UseGenocs()
    .UserCorrelationContextLogging()
    .UseErrorHandler()
    .UsePrometheus()
    .UseRouting()
    .UseCertificateAuthentication()
    .UseEndpoints(r => r.MapControllers())
    //.Get<GetOrder, OrderDto>("orders/{orderId}")
    //.Post<CreateOrder>("orders",
    //    afterDispatch: (cmd, ctx) => ctx.Response.Created($"orders/{cmd.OrderId}")))
    .UseSwaggerDocs()
    .UseRabbitMQ();
//    .SubscribeEvent<DeliveryStarted>();

// global cors policy
// app.UseCors(x => x
//    .SetIsOriginAllowed(origin => true)
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .AllowCredentials());

// app.UseHttpsRedirection();

// app.UseRouting();

// app.UseAuthorization();

// app.MapControllers();

app.MapDefaultEndpoints();

app.Run();

Log.CloseAndFlush();
