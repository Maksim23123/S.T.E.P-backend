namespace STEP_backend.Models.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserRole { get; set; }
    }

    public enum UserRoles
    {
        Teacher,
        Student
    }
}
