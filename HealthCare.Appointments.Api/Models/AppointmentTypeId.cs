using HealthCare.SharedAssets;

namespace HealthCare.Appointments.Api.Models
{
    public class AppointmentTypeId : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
