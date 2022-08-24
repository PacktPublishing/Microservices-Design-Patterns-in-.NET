using HealthCare.Appointments.Api.Models;
using MediatR;

namespace HealthCare.Appointments.Api.Commands;

public record GetAppointmentsQuery() : IRequest<List<Appointment>>;
