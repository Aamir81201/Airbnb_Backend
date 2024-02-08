namespace Airbnb.Model.DTO.Response
{
    public class UserStateResponseDTO
    {
        public string State { get; set; } = string.Empty;
        public string? Token { get; set; }
        public UserProfileResponseDTO? UserProfile { get; set; }
    }
}
