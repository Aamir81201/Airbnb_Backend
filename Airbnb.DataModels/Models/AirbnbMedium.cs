using System;
using System.Collections.Generic;

namespace Airbnb.DataModels.Models;

public partial class AirbnbMedium
{
    public Guid AirbnbMediaId { get; set; }

    public Guid AirbnbId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool HeroImage { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual Airbnb Airbnb { get; set; } = null!;
}
