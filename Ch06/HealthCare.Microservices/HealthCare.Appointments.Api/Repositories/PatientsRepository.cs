using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        public Task<Patient> Add(Patient appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Patient appointment)
        {
            throw new NotImplementedException();
        }
    }

}
