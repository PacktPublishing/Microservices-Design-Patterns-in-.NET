﻿using HealthCare.SharedAssets;

namespace HealthCare.Appointments.Api.Models
{
    public class Patient : BaseEntity<Guid>
    {
        public Patient(string name, string sex, string emailAddress, int? primaryDoctorId = null)
        {
            Name = name;
            Sex = sex;
            PreferredDoctorId = primaryDoctorId;
            EmailAddress = emailAddress;
        }

        public Patient(Guid id)
        {
            Id = id;
        }

        private Patient() // required for EF
        {
        }

        public string EmailAddress { get; private set; }
        public string Name { get; private set; }
        public string Sex { get; private set; }
        public int? PreferredDoctorId { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

}
