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
            string jsonTest = @"
            {
              ""questions"": [
                {
                  ""question"": ""What is the capital of France?"",
                  ""options"": [
                    ""Berlin"",
                    ""Madrid"",
                    ""Paris"",
                    ""Rome""
                  ],
                  ""correct_answer"": ""Paris""
                },
                {
                  ""question"": ""Which of the following are programming languages?"",
                  ""options"": [
                    ""Python"",
                    ""HTML"",
                    ""Java"",
                    ""CSS""
                  ],
                  ""correct_answers"": [
                    ""Python"",
                    ""Java""
                  ]
                },
                {
                  ""question"": ""Which planet is known as the Red Planet?"",
                  ""options"": [
                    ""Earth"",
                    ""Venus"",
                    ""Mars"",
                    ""Jupiter""
                  ],
                  ""correct_answer"": ""Mars""
                },
                {
                  ""question"": ""Select the prime numbers."",
                  ""options"": [
                    ""2"",
                    ""3"",
                    ""4"",
                    ""5""
                  ],
                  ""correct_answers"": [
                    ""2"",
                    ""3"",
                    ""5""
                  ]
                }
              ]
            }
            ";

            // Generate material ...

            if (material.Length > 0)
            {
                return Ok(jsonTest);
            }
            else
            {
                return BadRequest("Material required.");
            }
        }
    }
}
