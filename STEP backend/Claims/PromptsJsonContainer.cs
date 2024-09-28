using System.Text.Json.Serialization;

namespace STEP_backend.Claims
{
    public struct PromptsJsonContainer
    {
        [JsonPropertyName("generate-test-prompt")]
        public string GenerateTestPrompt { get; set; }

        [JsonPropertyName("generate-topic-prompt")]
        public string GenerateTopicPrompt { get; set; }

        [JsonPropertyName("test-format-example")]
        public string TestFormatExample { get; set; }
    }
}
