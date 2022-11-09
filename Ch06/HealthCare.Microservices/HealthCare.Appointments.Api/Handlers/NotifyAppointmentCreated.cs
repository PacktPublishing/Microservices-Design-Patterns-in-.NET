using HealthCare.Appointments.Api.Events;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Repositories;
using HealthCare.Appointments.Api.Service;
using HealthCare.SharedAssets.Emails;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class NotifyAppointmentCreated : INotificationHandler<AppointmentCreated>
    {
        private readonly IEmailSender _emailSender;
        private readonly IPatientsRepository _patientsRepository;
        private readonly ILogger<NotifyAppointmentCreated> _logger;

        public NotifyAppointmentCreated(IEmailSender emailSender, IPatientsRepository patientsRepository, ILogger<NotifyAppointmentCreated> logger)
        {
            this._emailSender = emailSender;
            this._patientsRepository = patientsRepository;
            this._logger = logger;
        }
        public async Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
        {
            
            _logger.LogInformation("Handling Email notification");
            
            // Get patient record via Patients API call
            
            // Create Email Message
            //var email = new Email
            //{
            //    Body = $"Appointment Created for {notification.Appointment.Start}",
            //    From = "noreply@appointments.com",
            //    Subject = "Appointment Created",
            //    To = patient.EmailAddress
            //};

            // Uncomment when email sender is configured
            //await _emailSender.SendEmail(email);
        }
    }
}
