using System.ComponentModel.DataAnnotations;

namespace STEP_backend.Entity
{
    public class TestProgress : BaseEntity<int>
    {
        public int TestId { get; set; }

        [Required]
        public string Status { get; set; }

        public int ResultRate { get; set; }

        public Test Test { get; set; }
    }
}
