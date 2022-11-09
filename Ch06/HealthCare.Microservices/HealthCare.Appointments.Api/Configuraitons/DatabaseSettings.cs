namespace HealthCare.Appointments.Api.Configuraitons;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string AppointmentCollectionName { get; set; } = null!;
}