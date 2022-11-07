using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTypesController : ControllerBase
    {
        private readonly AppointmentsDbContext _context;

        public AppointmentTypesController(AppointmentsDbContext context)
        {
            _context = context;
        }

        // GET: api/AppointmentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentType>>> GetAppointmentTypes()
        {
            return await _context.AppointmentTypes.ToListAsync();
        }

        // GET: api/AppointmentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentType>> GetAppointmentType(int id)
        {
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);

            if (appointmentType == null)
            {
                return NotFound();
            }

            return appointmentType;
        }

        // PUT: api/AppointmentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentType(int id, AppointmentType appointmentType)
        {
            if (id != appointmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentTypeExists(id))
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

        // POST: api/AppointmentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentType>> PostAppointmentType(AppointmentType appointmentType)
        {
            _context.AppointmentTypes.Add(appointmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentType", new { id = appointmentType.Id }, appointmentType);
        }

        // DELETE: api/AppointmentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentType(int id)
        {
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            if (appointmentType == null)
            {
                return NotFound();
            }

            _context.AppointmentTypes.Remove(appointmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentTypeExists(int id)
        {
            return _context.AppointmentTypes.Any(e => e.Id == id);
        }
    }
}
