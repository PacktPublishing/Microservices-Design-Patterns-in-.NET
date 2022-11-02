using HealthCare.SharedAssets;
using System;

namespace HealthCare.Appointments.Api.Models
{
    public class Document : BaseEntity<Guid>
    {
        public Document(Guid id,
          Guid patientId,
          int documentTypeId)
        {
            Id = id;
            DocumentTypeId = documentTypeId;
            PatientId = patientId;
        }

        private Document() { }

        public Guid PatientId { get; private set; }
        public int DocumentTypeId { get; private set; }
    }
}
