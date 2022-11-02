using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Repositories
{
    public interface IPatientsRepository
    {
        Task<Patient> Get(string id);
        Task<List<Patient>> GetAll();
        Task<Patient> Add(Patient appointment);
        Task<bool> Delete(string id);
        Task Update(Patient appointment);
        Task<bool> Exists(string id);
    }
}
