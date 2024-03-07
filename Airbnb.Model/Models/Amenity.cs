﻿namespace Airbnb.Model.Models;

public partial class Amenity
{
    public Guid AmenityId { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public Guid AmenityTypeId { get; set; }

    public virtual ICollection<AirbnbAmenity> AirbnbAmenities { get; set; } = new List<AirbnbAmenity>();

    public virtual AmenityType AmenityType { get; set; } = null!;
}
