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
        public string Title { get; set;} = string.Empty;
        public double Distance { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Price { get; set; } = String.Empty;
        public string? TotalPrice { get; set; }
        public string ShortDescription { get; set; } = String.Empty;
        public int? Beds { get; set; }
    }
}
