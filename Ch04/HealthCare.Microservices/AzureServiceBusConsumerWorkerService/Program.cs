using AzureServiceBusConsumerWorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddScoped<IAzureServiceBusConsumer, AzureServiceBusConsumer>();
    })
    .Build();

await host.RunAsync();
