namespace HealthCare.Appointments.MongoDb.Api.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AppointmentCollectionName { get; set; } = null!;
    }
}
