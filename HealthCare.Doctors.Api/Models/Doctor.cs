using HealthCare.SharedAssets;

namespace HealthCare.Doctors.Api.Models
{
    public class Doctor : BaseEntity<Guid>
    {
        public Doctor(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int? SpecializationId { get; private set; }
        public Specialization? Specialization { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
