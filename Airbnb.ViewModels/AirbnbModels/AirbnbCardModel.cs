using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.AirbnbModels
{
    public class AirbnbCardModel
    {
        public Guid AirbnbId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<string> AirbnbImages { get; set; } = new List<string> { string.Empty };
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public double Distance { get; set; } = 0;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Price { get; set; } = String.Empty;
    }
}
