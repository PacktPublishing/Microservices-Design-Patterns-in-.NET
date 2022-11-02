using HealthCare.SharedAssets;
using Microsoft.Extensions.Logging;
using System;

namespace HealthCare.Appointments.Api.Models
{
    public class Doctor : BaseEntity<Guid>, IAggregateRoot
    {
        public Doctor(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
