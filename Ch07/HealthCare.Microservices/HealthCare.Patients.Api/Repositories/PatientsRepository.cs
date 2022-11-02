using HealthCare.Patients.Api.Models;
using HealthCare.Patients.Api.Repositories;
using Microsoft.EntityFrameworkCore;

public class PatientsRepository : GenericRepository<Patient>, IPatientsRepository
{
    public PatientsRepository(ApplicationDatabaseContext context) : base(context)
    { }

    public async Task<Patient> GetByTaxIdAsync(string id)
    {
        return await _context.Patients.FirstOrDefaultAsync(q => q.TaxId == id);
    }
}
