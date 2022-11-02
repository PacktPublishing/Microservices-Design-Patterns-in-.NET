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

        public NotifyAppointmentCreated(IEmailSender emailSender, IPatientsRepository patientsRepository)
        {
            this._emailSender = emailSender;
            this._patientsRepository = patientsRepository;
        }
        public async Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
        {
            var patient = await _patientsRepository.Get(notification.Appointment.PatientId.ToString());
            string emailAddress = patient.EmailAddress;

            // Send Email Here
            var email = new Email
            {
                Body = $"Appointment Created for {notification.Appointment.Start}",
                From = "noreply@appointments.com",
                Subject = "Appointment Created",
                To = emailAddress
            };

            await _emailSender.SendEmail(email);
        }
    }
}
