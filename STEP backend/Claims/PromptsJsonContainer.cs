using System.Text.Json.Serialization;

namespace STEP_backend.Claims
{
    public struct PromptsJsonContainer
    {
        [JsonPropertyName("generate-test-prompt")]
        public string GenerateTestPrompt { get; set; }

        [JsonPropertyName("generate-material-prompt")]
        public string GenerateMaterialPrompt { get; set; }

        [JsonPropertyName("test-format-example")]
        public string TestFormatExample { get; set; }
    }
}
