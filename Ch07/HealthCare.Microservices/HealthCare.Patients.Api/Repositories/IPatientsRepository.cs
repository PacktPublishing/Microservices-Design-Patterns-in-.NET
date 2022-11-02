using HealthCare.Patients.Api.Models;
using HealthCare.Patients.Api.Repositories;

public interface IPatientsRepository : IGenericRepository<Patient>
{
    Task<Patient> GetByTaxIdAsync(string id);
}
