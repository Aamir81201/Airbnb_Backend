using System.ComponentModel.DataAnnotations;

namespace Airbnb.Model.DTO.Request
{
    public class SignupRequestDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; } = null;

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        public bool RecieveMarketingMessages { get; set; }

        public UserExternalAuthRequestDTO? ExternalUserAuth { get; set; }

        public bool IsExternal { get; set; }
    }
}
