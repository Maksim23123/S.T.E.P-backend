namespace STEP_backend.Entity
{
    public class Test : BaseEntity<int>
    {
        public IEnumerable<Question> Questions { get; set; }

    }

    public static class TestStatus
    {
        public static readonly string Completed = "Completed";
        public static readonly string NonCompleted = "NonCompleted";

    }
}
