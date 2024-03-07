namespace Airbnb.Model.Models;

public partial class AmenityType
{
    public Guid AmenityTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
}
