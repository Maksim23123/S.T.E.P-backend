using Microsoft.AspNetCore.Identity;
using STEP_backend.Models;
using STEP_backend.Models.Dtos;

namespace STEP_backend.Architecture.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterModel model);
        Task<UserDto> LoginAsync(LoginModel model);
    }
}
