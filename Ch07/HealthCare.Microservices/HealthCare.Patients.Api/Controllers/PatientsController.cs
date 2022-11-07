using HealthCare.Patients.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Patients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientsDatabaseContext _context;

        public PatientsController(PatientsDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            if (_context.Patients == null)
            {
                return NotFound();
            }
            return await _context.Patients.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> InsertPatient(Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
    }

}
