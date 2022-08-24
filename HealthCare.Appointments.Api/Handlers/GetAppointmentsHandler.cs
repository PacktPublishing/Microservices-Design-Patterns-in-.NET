using HealthCare.Appointments.Api.Commands;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Repositories;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class GetAppointmentsHandler : IRequestHandler<GetAppointmentsQuery, List<Appointment>>
    {
        private readonly IAppointmentRepository _repo;

        public GetAppointmentsHandler(IAppointmentRepository repo) => _repo = repo;

        public async Task<List<Appointment>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
           
            return await _repo.GetAll();
        }
    }

}
