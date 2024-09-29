using Microsoft.AspNetCore.Identity;
using STEP_backend.Architecture.Services;
using STEP_backend.Entity;
using STEP_backend.Models;
using STEP_backend.Models.Dtos;

namespace STEP_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserDto> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, model.Password)))
            {
                return null;
            }

            return new UserDto { Id = user.Id, Name = user.Name, UserRole = user.UserType };
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                throw new Exception("User already exists.");
            }
            ApplicationUser user = (model.UserRole == "Teacher") ? new Teacher
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Name = model.Email,
                Surname = model.Email
            } : new Student
            {
                Name = model.Email,
                Surname = model.Email,
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }
    }
}
