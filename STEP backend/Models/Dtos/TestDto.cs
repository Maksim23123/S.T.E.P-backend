namespace STEP_backend.Models.Dtos
{
    public class TestDto
    {
        public int Id { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
    }
}
