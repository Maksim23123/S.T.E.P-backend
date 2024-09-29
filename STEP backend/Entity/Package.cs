using System.ComponentModel.DataAnnotations;

namespace STEP_backend.Entity
{
    public class Package : BaseEntity<int>
    {
        [Required]
        public string TopicName { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public Test Test { get; set; }

        public string StudentId { get; set; }
    }
}
