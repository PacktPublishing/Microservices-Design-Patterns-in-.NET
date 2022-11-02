using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace HealthCare.Appointments.Api.Services;

public class MessagePublisher : IMessagePublisher
{
    private readonly IConfiguration configuration;

    public MessagePublisher(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task PublishMessage<T>(T data, string topicName)
    {
        await using var client = new ServiceBusClient(configuration["AzureServiceBusConnection"]);

        ServiceBusSender sender = client.CreateSender(topicName);

        var jsonMessage = JsonConvert.SerializeObject(data);
        ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
        {
            CorrelationId = Guid.NewGuid().ToString()
        };

        await sender.SendMessageAsync(finalMessage);

        await client.DisposeAsync();
    }
}  
