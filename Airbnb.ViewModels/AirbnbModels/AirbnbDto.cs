using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.AirbnbModels
{
    public class AirbnbDto
    {
        public Location CurrentLocation { get; set; } = new Location();
        public Bounds? Bounds { get; set; } 
    }
}
