using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels
{
    public class UserSignUpModel
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

        public UserExternalAuthModel? ExternalUserAuth { get; set; }
        public bool IsExternal { get; set; }
    }
}
    