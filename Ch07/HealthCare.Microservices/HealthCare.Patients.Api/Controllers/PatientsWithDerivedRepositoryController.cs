using HealthCare.Patients.Api.Models;
using HealthCare.SharedAssets.DataPaging;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Patients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsWithDerivedRepositoryController : ControllerBase
    {
        private readonly IPatientsRepository _repository;

        public PatientsWithDerivedRepositoryController(IPatientsRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/Patients/taxid/1234
        [HttpGet("taxid/{id}")]
        public async Task<ActionResult<Patient>> GetPatients(string id)
        {
            var patient = await _repository.GetByTaxIdAsync(id);
            if (patient is null) return NotFound();
            return patient;
        }

        // GET: api/Hotels/?StartIndex=0&pagesize=25&PageNumber=1
        [HttpGet()]
        public async Task<ActionResult<PagedResult<Patient>>> GetPatients([FromQuery] QueryParameters queryParameters)
        {
            return await _repository.GetAllAsync(queryParameters);
        }

    }


}
