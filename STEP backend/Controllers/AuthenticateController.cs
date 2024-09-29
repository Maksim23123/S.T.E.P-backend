using Microsoft.AspNetCore.Mvc;
using STEP_backend.Architecture.Services;
using STEP_backend.Models;

namespace STEP_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly IAuthService _authService;
        public AuthenticateController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var userDto = await _authService.LoginAsync(model);
            if (userDto != null)
            {
                return Ok(userDto);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var result = await _authService.RegisterAsync(model);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
