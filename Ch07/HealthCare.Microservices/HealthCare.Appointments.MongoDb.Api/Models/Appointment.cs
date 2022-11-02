using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HealthCare.Appointments.Api.Models
{
    public class Appointment 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; } = new Guid();

        public Guid PatientId { get;  set; }
        public Guid RoomId { get;  set; }
        public Guid DoctorId { get;  set; }

        public DateTime Start { get;  set; }

        public DateTime End { get;  set; }
        public string Title { get;  set; }
        public DateTime? DateTimeConfirmed { get; set; }
        public bool IsPotentiallyConflicting { get; set; }
    }
}
