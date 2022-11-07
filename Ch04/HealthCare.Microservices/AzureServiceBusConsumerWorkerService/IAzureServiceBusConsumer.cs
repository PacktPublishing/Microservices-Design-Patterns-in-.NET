namespace AzureServiceBusConsumerWorkerService
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }

}