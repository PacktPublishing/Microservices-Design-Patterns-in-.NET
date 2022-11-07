namespace AzureServiceBusConsumerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAzureServiceBusConsumer _azureServiceBusConsumer;

        public Worker(ILogger<Worker> logger, IAzureServiceBusConsumer azureServiceBusConsumer)
        {
            _logger = logger;
            this._azureServiceBusConsumer = azureServiceBusConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _azureServiceBusConsumer.Start();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _azureServiceBusConsumer.Stop();
            return base.StopAsync(cancellationToken);
        }
    }
}