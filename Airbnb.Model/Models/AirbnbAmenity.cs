namespace Airbnb.Model.Models;

public partial class AirbnbAmenity
{
    public Guid AirbnbAmenityId { get; set; }

    public Guid AmenityId { get; set; }

    public Guid AirbnbId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual Airbnb Airbnb { get; set; } = null!;

    public virtual Amenity Amenity { get; set; } = null!;
}
