using System.Text.Json.Serialization;

namespace STEP_backend.Models.Dtos.AIResponse
{
    public class GenerateTestResponseDto
    {
        public IEnumerable<GenerateTestQuestion> Questions { get; set; }
    }

    public class GenerateTestAnswer
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class GenerateTestQuestion
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("answers")]
        public IEnumerable<GenerateTestAnswer> Answers { get; set; }

        [JsonPropertyName("answerId")]
        public int AnswerId { get; set; }
    }
}
