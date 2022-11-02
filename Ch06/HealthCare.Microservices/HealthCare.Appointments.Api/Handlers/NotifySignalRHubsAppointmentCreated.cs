using HealthCare.Appointments.Api.Events;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class NotifySignalRHubsAppointmentCreated : INotificationHandler<AppointmentCreated>
    {
        public Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
        {
            // SignalR awesomeness here

            return Task.CompletedTask;
        }
    }

}
