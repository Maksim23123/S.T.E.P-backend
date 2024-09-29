using System.ComponentModel.DataAnnotations;

namespace STEP_backend.Entity
{
    public class Question : BaseEntity<long>
    {
        [Required]
        public string Title { get; set; }

        public IEnumerable<Answer> Answers { get; set; }

        public int TestId { get; set; }
    }
}
