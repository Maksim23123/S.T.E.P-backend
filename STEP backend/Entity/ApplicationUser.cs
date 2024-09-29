using Microsoft.AspNetCore.Identity;

namespace STEP_backend.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserType { get; }
    }
}
