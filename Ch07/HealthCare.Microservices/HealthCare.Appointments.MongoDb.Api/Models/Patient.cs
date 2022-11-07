namespace HealthCare.Appointments.Api.Models
{
    public class Patient
    {
        public Guid Id { get; set; } = new Guid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
