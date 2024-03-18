using Airbnb.Model.Common.Enum;

namespace Airbnb.Model.DTO.Response
{
    public class UserStateResponseDTO
    {
        public UserState State { get; set; }
        public string? Token { get; set; }
        public UserProfileResponseDTO? UserProfile { get; set; }
    }
}
