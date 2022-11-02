using AutoMapper;
using HealthCare.Appointments.Api.Constants;
using HealthCare.Appointments.Api.Dtos;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Repositories;
using HealthCare.Appointments.Api.Service;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IDoctorsApiRepository _doctorsApiRepository;
        private readonly IPatientsApiRepository _patientsApiRepository;
        private readonly ApiEndpoints _apiEndpoints;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMessagePublisher _messageBus;
        private readonly IAppointmentRepository _appointmentRepository;


        public AppointmentsController(IDoctorsApiRepository doctorsApiRepository, 
            IPatientsApiRepository patientsApiRepository, 
            ApiEndpoints apiEndpoints, 
            IMapper mapper, 
            IAppointmentRepository appointmentRepository, 
            IPublishEndpoint publishEndpoint,
            IMessagePublisher messageBus)
        {
            this._doctorsApiRepository = doctorsApiRepository;
            _patientsApiRepository = patientsApiRepository;
            this._apiEndpoints = apiEndpoints;
            this._mapper = mapper;
            _publishEndpoint = publishEndpoint;
            this._messageBus = messageBus;
            _appointmentRepository = appointmentRepository;

        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _appointmentRepository.GetAll();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> GetAppointment(string id)
        {
            var appointment = await _appointmentRepository.Get(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var doctor = await _doctorsApiRepository.Get(_apiEndpoints.GetDocumentsApi(), appointment.DoctorId.ToString());
            var patient = await _patientsApiRepository.Get(_apiEndpoints.GetPatientsApi(), appointment.PatientId.ToString());
            var appointmentDto = _mapper.Map<AppointmentDetailsDto>(appointment);
            appointmentDto.Doctor = _mapper.Map<DoctorDto>(doctor);
            appointmentDto.Patient = _mapper.Map<PatientDto>(patient);
            return appointmentDto;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(string id, Appointment appointment)
        {
            if (id != appointment.Id.ToString())
            {
                return BadRequest();
            }

            try
            {
                await _appointmentRepository.Update(appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AppointmentExistsAsync(id))
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
        public async Task<IActionResult> CreateAppointment(AppointmentDto appointmentDto)
        {

            var appointment = _mapper.Map<Appointment>(appointmentDto);

            //await _appointmentRepository.Add(appointment);

            var appointmentMessage = new AppointmentMessage()
            {
                Id = appointment.Id,
                CustomerId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                Date = appointment.Start
            };

            // Publish to RabbitMQ with MassTransit
            await _publishEndpoint.Publish(appointmentMessage);

            // Publish to Azure Service Bus
            await _messageBus.PublishMessage(appointmentMessage, "appointments");
            return Ok();
        }


        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var appointment = await _appointmentRepository.Get(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentRepository.Delete(id);
            
            return NoContent();
        }

        private async Task<bool> AppointmentExistsAsync(string id)
        {
            return await _appointmentRepository.Exists(id);
        }
    }
}

