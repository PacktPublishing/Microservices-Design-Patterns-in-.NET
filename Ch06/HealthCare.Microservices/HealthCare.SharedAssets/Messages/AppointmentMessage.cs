namespace HealthCare.Appointments.Api.Dtos
{
    public class AppointmentMessage
    {
        public AppointmentMessage()
        {
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}