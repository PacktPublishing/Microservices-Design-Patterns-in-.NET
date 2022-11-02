using HealthCare.SharedAssets;

namespace HealthCare.Patients.Api.Models
{
    public class Patient : BaseEntity<Guid>
    {
        public Patient()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();
    }
}
