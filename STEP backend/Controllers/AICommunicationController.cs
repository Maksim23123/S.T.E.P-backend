using Microsoft.AspNetCore.Mvc;
using STEP_backend.Architecture.Services;
using STEP_backend.Models.Dtos.AIRequest;

namespace STEP_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AICommunicationController : Controller
    {
        private readonly IAICommunicationService _aiCommunicationService;

        public AICommunicationController(IAICommunicationService aiCommunicationService)
        {
            _aiCommunicationService = aiCommunicationService;
        }

        [HttpPost("generate-test")]
        public async Task<IActionResult> GenerateTest([FromBody] GenerateTestRequestDto request)
        {
            try
            {
                var response = await _aiCommunicationService.GenerateTestAsync(request.TopicName, request.Material, request.Length);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("generate-material")]
        public async Task<IActionResult> GenerateMaterial([FromBody] GenerateMaterialRequestDto request)
        {
            try
            {
                var response = await _aiCommunicationService.GenerateTeachMaterialByTopic(request.TopicName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("generate-teach-mark")]
        public async Task<IActionResult> GenerateTeachMark([FromBody] GenerateTeachMarkRequestDto request)
        {
            try
            {
                var response = await _aiCommunicationService.GenerateTeachMark(request.Sentence, request.TopicName, request.Material);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
