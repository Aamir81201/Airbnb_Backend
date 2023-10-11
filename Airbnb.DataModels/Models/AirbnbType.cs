using System;
using System.Collections.Generic;

namespace Airbnb.DataModels.Models;

public partial class AirbnbType
{
    public Guid AirbnbTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual ICollection<Airbnb> Airbnbs { get; set; } = new List<Airbnb>();

    public virtual ICollection<Airbnbtemp> Airbnbtemps { get; set; } = new List<Airbnbtemp>();
}
