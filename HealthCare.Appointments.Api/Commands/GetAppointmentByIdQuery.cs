using HealthCare.Appointments.Api.Dtos;
using HealthCare.Appointments.Api.Models;
using MediatR;

namespace HealthCare.Appointments.Api.Commands;

public record GetAppointmentByIdQuery(string Id) : IRequest<AppointmentDetailsDto>;
