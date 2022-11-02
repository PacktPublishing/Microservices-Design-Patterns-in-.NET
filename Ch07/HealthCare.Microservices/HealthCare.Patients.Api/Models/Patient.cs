using HealthCare.SharedAssets;

namespace HealthCare.Patients.Api.Models
{
    public class Patient : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }

        // Using ? beside a data type indicates to the database that the field is nullable
        public DateTime? DateOfBirth { get; set; }
    }

}
