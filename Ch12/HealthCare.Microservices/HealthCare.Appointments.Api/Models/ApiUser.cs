using Microsoft.AspNetCore.Identity;

namespace HealthCare.Appointments.Api.Models;

public class ApiUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
