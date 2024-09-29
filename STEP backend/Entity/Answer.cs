using System.ComponentModel.DataAnnotations;

namespace STEP_backend.Entity
{
    public class Answer : BaseEntity<long>
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public bool isCorrect { get; set; }

        public long QuestionId { get; set; }

    }
}
