using HealthCare.Appointments.Api.Commands;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Repositories;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, string>
    {
        private readonly IAppointmentRepository _repo;

        public CreateAppointmentHandler(IAppointmentRepository repo) => _repo = repo;

        public async Task<string> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
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

            return newAppointment.Id.ToString();
        }
    }

}
