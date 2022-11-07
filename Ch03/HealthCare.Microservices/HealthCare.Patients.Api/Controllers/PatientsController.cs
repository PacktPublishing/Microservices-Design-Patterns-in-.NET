using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCare.Patients.Api.Models;
using Grpc.Net.Client;
using HealthCare.Documents.Api.Protos;
using HealthCare.Patients.Api.Dtos;

namespace HealthCare.Patients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientsDbContext _context;
        private readonly IConfiguration _configuration;

        public PatientsController(PatientsDbContext context, IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(Guid id)
        {
            var patient = await _context.Patients
                .Select(q => new PatientDto { 
                    Id = id,
                    LastName = q.LastName,
                    FirstName = q.FirstName,
                    DateOfBirth = q.DateOfBirth
                })
                .FirstOrDefaultAsync(q => q.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            using var channel = GrpcChannel.ForAddress(_configuration["DocumentsService"]);
            var client = new DocumentService.DocumentServiceClient(channel);
            var response = await client.GetAllAsync(new PatientId { PatientId_ = id.ToString() });
            patient.Documents = response.Documents.Select(q => new DocumentDto { 
                Name = q.Name,
                Path = q.Path,
            })
            .ToList();

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(Guid id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(Guid id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
