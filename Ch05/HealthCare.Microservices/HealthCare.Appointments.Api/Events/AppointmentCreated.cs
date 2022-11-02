
using DomainEventsConsole.Interfaces;
using HealthCare.Appointments.Api.Models;
using System;

namespace HealthCare.Appointments.Api.Events
{
    public class AppointmentCreated : IDomainEvent
    {
        public Appointment Appointment { get; set; }
        public DateTime ActionDate { get; private set; }

        public AppointmentCreated(Appointment appointment, DateTime dateCreated)
        {
            Appointment = appointment;
            ActionDate = dateCreated;
        }

        public AppointmentCreated(Appointment appointment) : this(appointment, DateTime.Now)
        {
        }
    }
}