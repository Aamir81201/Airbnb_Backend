namespace Airbnb.Model.Models;

public partial class AirbnbType
{
    public Guid AirbnbTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public virtual ICollection<Airbnb> Airbnbs { get; set; } = new List<Airbnb>();
}
