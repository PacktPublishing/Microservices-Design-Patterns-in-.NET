using HealthCare.SharedAssets;

namespace HealthCare.Appointments.Api.Models
{
    public class AppointmentType : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
