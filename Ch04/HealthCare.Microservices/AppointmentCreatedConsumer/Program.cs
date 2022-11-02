// See https://aka.ms/new-console-template for more information
using MassTransit;

Console.WriteLine("RabbitMQ Message Consumer using MassTransit");

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("appointment-created-event", e =>
    {
        e.Consumer<AppointmentCreatedConsumer>();
    });

});

await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");

    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}