using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.AirbnbModels
{
    public class AirbnbListModel
    {
        public int Count { get; set; }
        public List<AirbnbCardModel> Cards { get; set; } = new List<AirbnbCardModel>();
    }
}
