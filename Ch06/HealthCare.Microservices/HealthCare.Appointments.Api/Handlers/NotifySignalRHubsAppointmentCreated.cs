using HealthCare.Appointments.Api.Events;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class NotifySignalRHubsAppointmentCreated : INotificationHandler<AppointmentCreated>
    {
        private readonly ILogger<NotifySignalRHubsAppointmentCreated> _logger;

        public NotifySignalRHubsAppointmentCreated(ILogger<NotifySignalRHubsAppointmentCreated> logger)
        {
            this._logger = logger;
        }
        public Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
        {
            // SignalR awesomeness here
            _logger.LogInformation("Handling SignalR notification");
            return Task.CompletedTask;
        }
    }

}
