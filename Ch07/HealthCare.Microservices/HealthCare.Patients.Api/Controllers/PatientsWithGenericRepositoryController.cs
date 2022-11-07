using HealthCare.Patients.Api.Models;
using HealthCare.Patients.Api.Repositories;
using HealthCare.SharedAssets.DataPaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Patients.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsWithGenericRepositoryController : ControllerBase
{
    private readonly IGenericRepository<Patient> _repository;

    public PatientsWithGenericRepositoryController(IGenericRepository<Patient> repository)
    {
        _repository = repository;
    }
    // GET: api/Patients
    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        return await _repository.GetAllAsync();
    }

    // GET: api/Patients/?StartIndex=0&pagesize=25&PageNumber=1
    [HttpGet]
    public async Task<ActionResult<PagedResult<Patient>>> GetPatients([FromQuery] QueryParameters queryParameters)
    {
        return await _repository.GetAllAsync(queryParameters);
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> InsertPatient(Patient patient)
    {
        if (patient == null)
        {
            return BadRequest();
        }
        await _repository.Insert(patient);
        return patient;
    }

    [HttpPut]
    public async Task<ActionResult<Patient>> UpdatePatient(Patient patient)
    {
        if (patient == null)
        {
            return BadRequest();
        }
        await _repository.Update(patient);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeletePatient(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        await _repository.Delete(id.Value);
        return NoContent();
    }

}