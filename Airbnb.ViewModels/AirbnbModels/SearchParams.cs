using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.AirbnbModels
{
    public class SearchParams
    {
        public string? PlaceId { get; set; }
        public Bounds? Bounds { get; set; }
        public int Guests { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
