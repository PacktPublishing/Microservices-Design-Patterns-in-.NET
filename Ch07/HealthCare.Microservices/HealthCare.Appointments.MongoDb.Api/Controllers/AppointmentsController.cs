using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.MongoDb.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly AppointmentsService _appointmentsService;

    public AppointmentsController(AppointmentsService appointmentsService) =>
        _appointmentsService = appointmentsService;

    [HttpGet]
    public async Task<List<Appointment>> Get() =>
        await _appointmentsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Appointment>> Get(string id)
    {

        var appointment = await _appointmentsService.GetAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        return appointment;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Appointment newAppointment)
    {
        await _appointmentsService.CreateAsync(newAppointment);

        return CreatedAtAction(nameof(Get), new { id = newAppointment.Id }, newAppointment);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Appointment updatedAppointment)
    {
        var appointment = await _appointmentsService.GetAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        updatedAppointment.Id = appointment.Id;

        await _appointmentsService.UpdateAsync(id, updatedAppointment);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var appointment = await _appointmentsService.GetAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        await _appointmentsService.RemoveAsync(id);

        return NoContent();
    }
}