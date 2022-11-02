using HealthCare.SharedAssets;
using System;

namespace HealthCare.Appointments.Api.Models
{
    public class Appointment : BaseEntity<Guid>
    {
        public Appointment(Guid id,
          int appointmentTypeId,
          Guid doctorId,
          Guid patientId,
          Guid roomId,
          DateTime start,
          DateTime end,
          string title,
          DateTime? dateTimeConfirmed = null)
{
            Id = id;
            AppointmentTypeId = appointmentTypeId;
            DoctorId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            Start = start;
            End = end; 
            Title = title;
            DateTimeConfirmed = dateTimeConfirmed;
        }

        private Appointment() { }

        public Guid PatientId { get; private set; }
        public Guid RoomId { get; private set; }
        public Guid DoctorId { get; private set; }
        public int AppointmentTypeId { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }
        public string Title { get; private set; }
        public DateTime? DateTimeConfirmed { get; set; }
        public bool IsPotentiallyConflicting { get; set; }

        public void UpdateRoom(Guid newRoomId)
{
            if (newRoomId == RoomId) return;

            RoomId = newRoomId;
        }

        public void UpdateDoctor(Guid newDoctorId)
{
            if (newDoctorId == DoctorId) return;

            DoctorId = newDoctorId;
        }

        public void UpdateStartTime(DateTime newStartTime,
          Action scheduleHandler)
        {
            if (newStartTime == Start) return;

            Start = newStartTime;

            scheduleHandler?.Invoke();
        }

        public void UpdateTitle(string newTitle)
        {
            if (newTitle == Title) return;

            Title = newTitle;

        }

        public void Confirm(DateTime dateConfirmed)
        {
            if (DateTimeConfirmed.HasValue) return; 

            DateTimeConfirmed = dateConfirmed;

        }
    }
}
