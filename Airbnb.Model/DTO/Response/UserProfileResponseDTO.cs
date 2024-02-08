namespace Airbnb.Model.DTO.Response
{
    public class UserProfileResponseDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public string? Provider { get; set; }
    }
}
