namespace STEP_backend.Entity
{
    public class Student : ApplicationUser
    {
        public IEnumerable<Package> Packages { get; set; }

        public IEnumerable<TestProgress> TestProgresses { get; set; }
    }
}
