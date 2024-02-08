namespace Airbnb.ViewModels
{
    public class UserExternalAuthRequestDTO
    {
        public string TokenId { get; set; } = string.Empty;
        public string Provider { get; set; }
    }
}
