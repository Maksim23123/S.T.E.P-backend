namespace STEP_backend.Models.Dtos
{
    public class QuestionDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}
