namespace STEP_backend.Models.Dtos.AIRequest
{
    public class GenerateTeachMarkRequestDto
    {
        public string TopicName { get; set; }
        public string Material { get; set; }
        public string Sentence { get; set; }
    }
}
