using HealthCare.Appointments.Api.Models;
using MediatR;

namespace HealthCare.Appointments.Api.Commands;

public record CreateAppointmentCommand(int AppointmentTypeId, Guid DoctorId, Guid PatientId, Guid RoomId, DateTime Start, DateTime End, string Title) : IRequest<Appointment>;
