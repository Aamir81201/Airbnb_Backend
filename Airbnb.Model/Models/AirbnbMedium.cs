﻿namespace Airbnb.Model.Models;

public partial class AirbnbMedium
{
    public Guid AirbnbMediaId { get; set; }

    public Guid AirbnbId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool HeroImage { get; set; }

    public virtual Airbnb Airbnb { get; set; } = null!;
}
