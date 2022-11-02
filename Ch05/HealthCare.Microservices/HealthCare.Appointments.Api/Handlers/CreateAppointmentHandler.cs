using HealthCare.Appointments.Api.Commands;
using HealthCare.Appointments.Api.Dtos;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Repositories;
using HealthCare.Appointments.Api.Service;
using MassTransit;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, Appointment>
    {
        private readonly IAppointmentRepository _repo;
        private readonly IEmailSender _emailSender;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMessagePublisher _messageBus;

        public CreateAppointmentHandler(IAppointmentRepository repo, IEmailSender emailSender, IPublishEndpoint publishEndpoint, IMessagePublisher messageBus)
        {
            _repo = repo;
            this._emailSender = emailSender;
            _publishEndpoint = publishEndpoint;
            _messageBus = messageBus;
        }

        public async Task<Appointment> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            // Handle Pre-checks and Validations Here
            var newAppointment = new Appointment
            (
                Guid.NewGuid(),
                request.AppointmentTypeId,
                request.DoctorId,
                request.PatientId,
                request.RoomId,
                request.Start,
                request.End,
                request.Title
            );
            await _repo.Add(newAppointment);

            //Perform post creation hand off to services bus. 
            var appointmentMessage = new AppointmentMessage()
            {
                Id = newAppointment.Id,
                CustomerId = newAppointment.PatientId,
                DoctorId = newAppointment.DoctorId,
                Date = newAppointment.Start
            };

            // Publish to RabbitMQ with MassTransit
            await _publishEndpoint.Publish(appointmentMessage);

            // Publish to Azure Service Bus
            await _messageBus.PublishMessage(appointmentMessage, "appointments");

            return newAppointment;
        }
    }

}
