using AutoMapper;
using HealthCare.Appointments.Api.Constants;
using HealthCare.Appointments.Api.Dtos;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentsDbContext _context;
        private readonly IPatientsApiRepository _patientsApiRepository;
        private readonly ApiEndpoints _apiEndpoints;
        private readonly IMapper _mapper;

        public AppointmentsController(AppointmentsDbContext context, IPatientsApiRepository patientsApiRepository, ApiEndpoints apiEndpoints, IMapper mapper)
        {
            _context = context;
            _patientsApiRepository = patientsApiRepository;
            this._apiEndpoints = apiEndpoints;
            this._mapper = mapper;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> GetAppointment(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }
            // Other service calls
            var patient = await _patientsApiRepository.GetPatient(appointment.PatientId.ToString());
            var appointmentDto = _mapper.Map<AppointmentDetailsDto>(appointment);
            appointmentDto.Patient = _mapper.Map<PatientDto>(patient);
            return appointmentDto;
        }
    }
}
