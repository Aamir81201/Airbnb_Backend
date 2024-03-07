namespace Airbnb.Model.Models;

public partial class AirbnbCategory
{
    public Guid AirbnbCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public virtual ICollection<Airbnb> Airbnbs { get; set; } = new List<Airbnb>();
}
