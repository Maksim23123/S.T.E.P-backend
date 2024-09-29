using Microsoft.AspNetCore.Mvc;
using STEP_backend.Architecture.Services;
using STEP_backend.Models.Dtos;

namespace STEP_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpPost("create-package")]
        public async Task<IActionResult> CreatePackage([FromBody] PackageDto packageDto)
        {
            try
            {
                await _packageService.CreatePackage(packageDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-student-packages/{studentId}")]
        public async Task<IActionResult> GetStudentPackagesById(string studentId)
        {
            try
            {
                var packages = await _packageService.GetAllPackagesOfStudentId(studentId);
                return Ok(packages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
