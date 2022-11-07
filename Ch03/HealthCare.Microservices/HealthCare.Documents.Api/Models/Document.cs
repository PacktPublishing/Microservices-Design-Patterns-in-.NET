using HealthCare.SharedAssets;
using System;

namespace HealthCare.Documents.Api.Models
{
    public class Document : BaseEntity<Guid>
    {
        public Document(Guid id,
          Guid patientId,
          string name,
          string path)
        {
            Id = id;
            PatientId = patientId;
            Path = path;
            Name = name;
        }

        public Guid PatientId { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
    }
}
