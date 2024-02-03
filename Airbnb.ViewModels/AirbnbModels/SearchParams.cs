using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.AirbnbModels
{
    public class SearchParams
    {
        public RegionModel? Region { get; set; }
        public Bounds? Bounds { get; set; }
        public GuestModel? Guests { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class RegionModel
    {
        public string Input { get; set; } = null!;
        public string PlaceId { get; set; } = null!;
    }

}