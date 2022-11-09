using AutoMapper;
using HealthCare.Appointments.Api.Dtos;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Queries;
using HealthCare.Appointments.Api.Repositories;
using MediatR;

namespace HealthCare.Appointments.Api.Handlers
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentDetailsDto>
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;

        public GetAppointmentByIdHandler(IAppointmentRepository repo, IMapper mapper) 
        {
            _repo = repo;
            this._mapper = mapper;
        }

        public async Task<AppointmentDetailsDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            // Carry out all query operations and convert the result to the expected return type
            return _mapper.Map<AppointmentDetailsDto>(await _repo.Get(request.Id));
        }
    }

}
