using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace STEP_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestGenerationController : Controller
    {
        // Placeholder
        [HttpPost("generate-test")]
        public ActionResult GenerateTest([FromBody] string material = "")
        {
            // Generate material ...

            if (material.Length > 0)
            {
                return Ok(DataPlaceholders.JsonGeneratedTest);
            }
            else
            {
                return BadRequest("Material required.");
            }
        }
    }
}
