using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.AirbnbModels
{
    public class AirbnbRequestDTO
    {
        public double CurrentPage { get; set; }
        public float CardsPerPage { get; set; }
        public Location CurrentLocation { get; set; } = new Location();
        public Bounds? Bounds { get; set; }
        public string? CategoryId { get; set; }
        public SearchParams? SearchParams { get; set; }
    }
}
