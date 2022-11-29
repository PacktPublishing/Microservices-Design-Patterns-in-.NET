using HealthCare.Appointments.Api.Commands;
using HealthCare.Appointments.Api.Dtos;
using HealthCare.Appointments.Api.Events;
using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.Api.Queries;
using HealthCare.Appointments.Api.Service;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCare.Appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentsController(IMediator mediator) => _mediator = mediator;


        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAppointmentCommand createAppointmentCommand)
        {
            var appointment = await _mediator.Send(createAppointmentCommand);
            await _mediator.Publish(new AppointmentCreated(appointment));
            return StatusCode(201);
        }

        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<ActionResult<Appointment>> Get()
        {
            var appointments = await _mediator.Send(new GetAppointmentsQuery());
            return Ok(appointments);
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> Get(string id)
        {
            var appointment = await _mediator.Send(new GetAppointmentByIdQuery(id));
            return Ok(appointment);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
