using Genocs.Core.Builders;
using Genocs.Logging;
using Genocs.Monitoring;
using Genocs.Persistence.MongoDb.Extensions;
using Genocs.WebApiTemplate.Worker;
using Genocs.WebApiTemplate.Worker.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Serilog.Events;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();


IHost host = Host.CreateDefaultBuilder(args)
    .UseLogging()
    .ConfigureServices((hostContext, services) =>
    {
        // Run the hosted service 
        services.AddHostedService<MassTransitConsoleHostedService>();

        services
            .AddGenocs(hostContext.Configuration)
            .AddMongoFast() // It adds the MongoDb Repository to the project and register all the Domain Objects with the standard interface
            .RegisterMongoRepositories(Assembly.GetExecutingAssembly()); // It registers the repositories that has been overridden. No need in case of standard repository

        //RegisterCustomMongoRepository(services, hostContext.Configuration);


        ConfigureMassTransit(services, hostContext.Configuration);

        services.AddCustomOpenTelemetry(hostContext.Configuration);
    })
    .Build();

await host.RunAsync();

Log.CloseAndFlush();


static IServiceCollection ConfigureMassTransit(IServiceCollection services, IConfiguration configuration)
{
    services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
    services.AddMassTransit(cfg =>
    {
        // Consumer configuration
        cfg.AddConsumersFromNamespaceContaining<SubmitOrderConsumer>();

        // Set the transport
        cfg.UsingRabbitMq(ConfigureBus);
    });

    return services;
}

static IServiceCollection RegisterCustomMongoRepository(IServiceCollection services, IConfiguration configuration)
{
    //services.AddScoped<IRepository<Order, ObjectId>, Genocs.Persistence.MongoDb.Repositories.MongoDbRepository<Order>>();

    return services;
}

static void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
{
    //configurator.UseMessageData(new MongoDbMessageDataRepository("mongodb://127.0.0.1", "attachments"));

    //configurator.ReceiveEndpoint(KebabCaseEndpointNameFormatter.Instance.Consumer<RoutingSlipBatchEventConsumer>(), e =>
    //{
    //    e.PrefetchCount = 20;

    //    e.Batch<RoutingSlipCompleted>(b =>
    //    {
    //        b.MessageLimit = 10;
    //        b.TimeLimit = TimeSpan.FromSeconds(5);

    //        b.Consumer<RoutingSlipBatchEventConsumer, RoutingSlipCompleted>(context);
    //    });
    //});

    // This configuration allow to handle the Scheduling
    configurator.UseMessageScheduler(new Uri("queue:quartz"));

    // This configuration will configure the Activity Definition
    configurator.ConfigureEndpoints(context);
}