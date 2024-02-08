using Microsoft.AspNetCore.Identity;

namespace Airbnb.Model.Models;

public partial class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? Avatar { get; set; }

    public bool RecieveMarketingMessages { get; set; } = true;
}
