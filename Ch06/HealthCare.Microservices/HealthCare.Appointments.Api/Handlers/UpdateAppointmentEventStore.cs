using HealthCare.Appointments.Api.Events;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Repositories;
using HealthCare.Appointments.Api.Service;
using HealthCare.SharedAssets.Emails;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class UpdateAppointmentEventStore : INotificationHandler<AppointmentCreated>
    {
        private readonly ILogger<UpdateAppointmentEventStore> _logger;
        private readonly AppointmentsEventStoreService _appointmentsEventStore;

        public UpdateAppointmentEventStore(ILogger<UpdateAppointmentEventStore> logger, AppointmentsEventStoreService appointmentsEventStore)
        {
            this._logger = logger;
            this._appointmentsEventStore = appointmentsEventStore;
        }
        public async Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updated Appointment Event Store with current record snapshot");
            
            // uncomment when you have configured a mongodb database with the collection. See appsettings.json
            //await _appointmentsEventStore.CreateAsync(notification.Appointment);
        }
    }
}
