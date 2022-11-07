using Azure.Messaging.ServiceBus;

namespace AzureServiceBusConsumerWorkerService
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly ServiceBusProcessor appointmentProcessor;
        private readonly string appointmentSubscription;
        private readonly IConfiguration _configuration;

        public AzureServiceBusConsumer(IConfiguration configuration)
        {
            _configuration = configuration;
            string appointmentSubscription = _configuration.GetValue<string>("AppointmentProcessSubscription");
            var client = new ServiceBusClient(appointmentSubscription);

            appointmentProcessor = client.CreateProcessor("appointments", appointmentSubscription);
        }

        public async Task Start()
        {
            appointmentProcessor.ProcessMessageAsync += ProcessAppointment;
            appointmentProcessor.ProcessErrorAsync += ErrorHandler;
            await appointmentProcessor.StartProcessingAsync();
        }

        public async Task Stop()
        {
            await appointmentProcessor.StopProcessingAsync();
            await appointmentProcessor.DisposeAsync();
        }


        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task ProcessAppointment(ProcessMessageEventArgs args)
        {
            // Code to extract the message from the args, parse to a concrete type, and complete processing – like forming email, etc…     
            await args.CompleteMessageAsync(args.Message);
        }
    }

}