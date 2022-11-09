using HealthCare.Appointments.Api.Models;
using MediatR;

namespace HealthCare.Appointments.Api.Queries;

public record GetAppointmentsQuery() : IRequest<List<Appointment>>;
