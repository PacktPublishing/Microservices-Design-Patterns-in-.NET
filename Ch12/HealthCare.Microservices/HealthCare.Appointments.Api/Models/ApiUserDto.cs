using System.ComponentModel.DataAnnotations;

namespace HealthCare.Appointments.Api.Models;

public class ApiUserDto : LoginDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
}
