namespace HealthCare.Patients.Api.Dtos;

public class PatientDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<DocumentDto> Documents { get; set; } = new List<DocumentDto>();
}
