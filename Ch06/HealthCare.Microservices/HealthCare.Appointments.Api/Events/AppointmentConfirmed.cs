using DomainEventsConsole.Interfaces;
using HealthCare.Appointments.Api.Models;
using System;

namespace DomainEventsConsole.Events
{
    public class AppointmentConfirmed : IDomainEvent
    {
        public Appointment Appointment { get; set; }
        public DateTime ActionDate { get; private set; }

        public AppointmentConfirmed(Appointment appointment, DateTime dateConfirmed)
        {
            Appointment = appointment;
            ActionDate = dateConfirmed;
        }
        public AppointmentConfirmed(Appointment appointment) : this(appointment, DateTime.Now)
        {
        }
    }
}