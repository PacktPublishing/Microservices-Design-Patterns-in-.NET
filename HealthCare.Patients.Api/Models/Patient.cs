using HealthCare.SharedAssets;

namespace HealthCare.Patients.Api.Models
{
    public class Patient : BaseEntity<Guid>
    {
        public Patient(string firstame, string lastName)
        {
            FirstName = firstame;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
