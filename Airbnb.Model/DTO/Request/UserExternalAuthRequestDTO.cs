using Airbnb.Model.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Model.DTO.Request
{
    public class UserExternalAuthRequestDTO
    {
        [Required]
        public string TokenId { get; set; } = string.Empty;
        [Required]
        public string Provider { get; set; } = string.Empty;
    }
}
