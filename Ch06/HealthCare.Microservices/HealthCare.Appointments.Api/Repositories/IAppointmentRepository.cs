using HealthCare.Appointments.Api.Models;
using HealthCare.SharedAssets;

namespace HealthCare.Appointments.Api.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> Get(string id);
        Task<List<Appointment>> GetAll();
        Task<Appointment> Add(Appointment appointment);
        Task Delete(string id);
        Task Update(Appointment appointment);
        Task<bool> Exists(string id);
    }
}
