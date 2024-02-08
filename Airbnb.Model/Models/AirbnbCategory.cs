namespace Airbnb.Model.Models;

public partial class AirbnbCategory
{
    public Guid AirbnbCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual ICollection<Airbnb> Airbnbs { get; set; } = new List<Airbnb>();

    public virtual ICollection<Airbnbtemp> Airbnbtemps { get; set; } = new List<Airbnbtemp>();
}
