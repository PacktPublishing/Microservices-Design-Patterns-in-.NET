using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.MongoDb.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HealthCare.Appointments.MongoDb.Api.Services;

public class AppointmentsService
{
    private readonly IMongoCollection<Appointment> _appointmentsCollection;

    public AppointmentsService(
        IOptions<DatabaseSettings> appointmentStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            appointmentStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            appointmentStoreDatabaseSettings.Value.DatabaseName);

        _appointmentsCollection = mongoDatabase.GetCollection<Appointment>(
            appointmentStoreDatabaseSettings.Value.AppointmentCollectionName);
    }

    public async Task<List<Appointment>> GetAsync() =>
        await _appointmentsCollection.Find(_ => true).ToListAsync();

    public async Task<Appointment?> GetAsync(string id) =>
        await _appointmentsCollection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Appointment newAppointment) =>
        await _appointmentsCollection.InsertOneAsync(newAppointment);

    public async Task UpdateAsync(string id, Appointment updatedAppointment) =>
        await _appointmentsCollection.ReplaceOneAsync(x => x.Id.ToString() == id, updatedAppointment);

    public async Task RemoveAsync(string id) =>
        await _appointmentsCollection.DeleteOneAsync(x => x.Id.ToString() == id);
}