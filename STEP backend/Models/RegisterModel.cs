using System.ComponentModel.DataAnnotations;

namespace STEP_backend.Models
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string UserRole { get; set; }
    }
}
