namespace Airbnb.Model.CustomModels
{
    public class UserAuthModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public IList<string> Role { get; set; } = new List<string>();
        public string? Avatar { get; set; }
    }
}
