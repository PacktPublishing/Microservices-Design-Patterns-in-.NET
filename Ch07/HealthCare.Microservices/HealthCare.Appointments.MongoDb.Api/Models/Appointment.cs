using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HealthCare.Appointments.Api.Models;

public class Appointment 
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public Patient Patient { get;  set; }
    public Room Room { get;  set; }
    public Guid DoctorId { get;  set; }

    public DateTime Start { get;  set; }

    public DateTime End { get;  set; }
    public string Title { get;  set; }
    public DateTime? DateTimeConfirmed { get; set; }
    public bool IsPotentiallyConflicting { get; set; }
}
