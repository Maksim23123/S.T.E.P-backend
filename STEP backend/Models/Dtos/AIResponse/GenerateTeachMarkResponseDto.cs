using System.Text.Json.Serialization;

namespace STEP_backend.Models.Dtos.AIResponse
{
    public class GenerateTeachMarkResponseDto
    {
        [JsonPropertyName("mark")]
        public int Mark { get; set; }
    }
}
