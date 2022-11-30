using HealthCare.Appointments.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HealthCare.Appointments.Api.Service
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
