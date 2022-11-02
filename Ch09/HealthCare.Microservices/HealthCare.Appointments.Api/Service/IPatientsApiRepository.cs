using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Service
{
    public interface IPatientsApiRepository 
    {
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatient(string id);
    }
}
