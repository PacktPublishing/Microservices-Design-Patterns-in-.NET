using HealthCare.SharedAssets;

namespace HealthCare.Patients.Api.Models
{
    public class Document : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
