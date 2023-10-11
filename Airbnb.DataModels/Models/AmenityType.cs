using System;
using System.Collections.Generic;

namespace Airbnb.DataModels.Models;

public partial class AmenityType
{
    public Guid AmenityTypeId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
}
