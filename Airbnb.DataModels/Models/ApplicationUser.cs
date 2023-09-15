using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Airbnb.DataModels.Models;

public partial class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? Avatar { get; set; }

    public bool RecieveMarketingMessages { get; set; } = true;
}
