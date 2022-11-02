using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Service
{
    public class DoctorsApiRepository : HttpRepository<Doctor>, IDoctorsApiRepository
    {
        public DoctorsApiRepository(HttpClient client) : base(client)
        {
        }
    }
}
