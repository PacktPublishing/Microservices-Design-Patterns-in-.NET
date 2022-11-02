using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public Task<Appointment> Add(Appointment appointment)
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

        public Task<Appointment> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }

}
