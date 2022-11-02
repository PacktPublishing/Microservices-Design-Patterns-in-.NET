using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Service
{
    public class PatientsApiRepository : HttpRepository<Patient>, IPatientsApiRepository
    {
        public PatientsApiRepository(HttpClient client) : base(client)
        {
        }
    }
}
