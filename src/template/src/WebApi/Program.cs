using Genocs.Core.Builders;
using Genocs.Core.CQRS.Commands;
using Genocs.Core.CQRS.Events;
using Genocs.Core.CQRS.Queries;
using Genocs.Discovery.Consul;
using Genocs.HTTP;
using Genocs.LoadBalancing.Fabio;
using Genocs.Logging;
using Genocs.MessageBrokers.Outbox;
using Genocs.MessageBrokers.Outbox.MongoDB;
using Genocs.MessageBrokers.RabbitMQ;
using Genocs.Metrics.Prometheus;
using Genocs.Monitoring;
using Genocs.Persistence.MongoDb.Extensions;
using Genocs.Persistence.Redis;
using Genocs.Secrets.Vault;
using Genocs.WebApi;
using Genocs.WebApi.CQRS;
using Genocs.WebApi.Security;
using Genocs.WebApi.Swagger;
using Genocs.WebApi.Swagger.Docs;
using Genocs.Library.Template.WebApi;
using Genocs.Library.Template.WebApi.Infrastructure.Extensions;
using Serilog;
using Genocs.Tracing;

StaticLogger.EnsureInitialized();

var builder = WebApplication.CreateBuilder(args);

builder.Host
        .UseLogging()
        .UseVault();

var services = builder.Services;

services.AddGenocs()
        .AddErrorHandler<ExceptionToResponseMapper>()
        .AddServices()
        .AddHttpClient()
        .AddCorrelationContextLogging()
        .AddConsul()
        .AddFabio()
        .AddOpenTelemetry()
        .AddMongo()
        // .AddMongoRepository<Product, Guid>("products")
        .AddCommandHandlers()
        .AddEventHandlers()
        .AddQueryHandlers()
        .AddInMemoryCommandDispatcher()
        .AddInMemoryEventDispatcher()
        .AddInMemoryQueryDispatcher()
        .AddPrometheus()
        .AddRedis()
        .AddRabbitMq()
        .AddMessageOutbox(o => o.AddMongo())
        .AddWebApi()
        .AddSwaggerDocs()
        .AddWebApiSwaggerDocs()
        .Build();

// START: TO be Refactory

//services.AddMongoDatabase(builder.Configuration);
//services.RegisterRepositories(Assembly.GetExecutingAssembly());

//services.AddCors();
//services.AddControllers().AddJsonOptions(x =>
//{
//    // serialize Enums as strings in api responses (e.g. Role)
//    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//});

//services.AddHealthChecks();

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

// Set Custom Open telemetry
services.AddCustomOpenTelemetry(builder.Configuration);

var app = builder.Build();

// START: TO be Refactory

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
    .UseDispatcherEndpoints(endpoints => endpoints
        .Get(string.Empty, ctx => ctx.Response.WriteAsync("Genocs.Library.Template Service"))
        .Get("ping", ctx => ctx.Response.WriteAsync("pong")))
    //.Get<GetOrder, OrderDto>("orders/{orderId}")
    //.Post<CreateOrder>("orders",
    //    afterDispatch: (cmd, ctx) => ctx.Response.Created($"orders/{cmd.OrderId}")))
    .UseSwaggerDocs()
    .UseRabbitMq();
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

// app.MapHealthChecks("/hc");

app.Run();

Log.CloseAndFlush();
