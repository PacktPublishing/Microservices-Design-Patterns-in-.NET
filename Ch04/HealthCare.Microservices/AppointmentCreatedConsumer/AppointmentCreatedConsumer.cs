// See https://aka.ms/new-console-template for more information
using HealthCare.Appointments.Api.Dtos;
using MassTransit;
using Newtonsoft.Json;

public class AppointmentCreatedConsumer : IConsumer<AppointmentMessage>
{
    public async Task Consume(ConsumeContext<AppointmentMessage> context)
    {
        // Code to extract the message from the context and complete processing – like forming email, etc…
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"ApoointmentCreated message: {jsonMessage}");
    }
}

