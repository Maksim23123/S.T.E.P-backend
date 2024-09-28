namespace STEP_backend.Models.Dtos.AIRequest
{
    public class GenerateTestRequestDto
    {
        public string TopicName { get; set; }

        public string Material { get; set; }

        public int Length { get; set; }
    }
}
