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
        private readonly IDoctorsApiRepository _doctorsApiRepository;
        private readonly IPatientsApiRepository _patientsApiRepository;
        private readonly ApiEndpoints _apiEndpoints;
        private readonly IMapper _mapper;

        public AppointmentsController(AppointmentsDbContext context, 
            IDoctorsApiRepository doctorsApiRepository, 
            IPatientsApiRepository patientsApiRepository, 
            ApiEndpoints apiEndpoints, 
            IMapper mapper)
        {
            _context = context;
            this._doctorsApiRepository = doctorsApiRepository;
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

            var doctor = await _doctorsApiRepository.Get(_apiEndpoints.GetDoctorsApi(), appointment.DoctorId.ToString());
            var patient = await _patientsApiRepository.Get(_apiEndpoints.GetPatientsApi(), appointment.PatientId.ToString());
            var appointmentDto = _mapper.Map<AppointmentDetailsDto>(appointment);
            appointmentDto.Doctor = _mapper.Map<DoctorDto>(doctor);
            appointmentDto.Patient = _mapper.Map<PatientDto>(patient);
            return appointmentDto;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(Guid id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(Guid id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
