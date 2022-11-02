
namespace HealthCare.Appointments.Api.Dtos
{
    public class AppointmentDto
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }

        public int AppointmentTypeId { get; set; }
        public DateTime DateStart { get;  set; }
        public Guid RoomId { get;  set; }
        public string Title { get;  set; }
        public DateTime DateEnd { get;  set; }
    }
}
