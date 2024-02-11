using System.ComponentModel.DataAnnotations;

namespace Airbnb.Model.DTO.Request
{
    public class VerifyResetPasswordRequestDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
