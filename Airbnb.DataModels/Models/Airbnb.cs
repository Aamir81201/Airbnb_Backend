using System;
using System.Collections.Generic;

namespace Airbnb.DataModels.Models;

public partial class Airbnb
{
    public Guid AirbnbId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public decimal Price { get; set; }

    public int Guests { get; set; }

    public int Bedrooms { get; set; }

    public int Beds { get; set; }

    public decimal Bathrooms { get; set; }

    public Guid AirbnbTypeId { get; set; }

    public Guid CategoryId { get; set; }

    public Guid HostId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual ICollection<AirbnbAmenity> AirbnbAmenities { get; set; } = new List<AirbnbAmenity>();

    public virtual ICollection<AirbnbMedium> AirbnbMedia { get; set; } = new List<AirbnbMedium>();

    public virtual AirbnbType AirbnbType { get; set; } = null!;

    public virtual AirbnbCategory Category { get; set; } = null!;

    public virtual AspNetUser Host { get; set; } = null!;
}