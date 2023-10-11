using Airbnb.ViewModels.AirbnbModels;
using Airbnb.ViewModels.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Repository.Interface
{
    public interface IAirbnbRepository
    {
        List<string> GetNames();
        List<CategoryModel> GetCategories();
        List<AirbnbCardModel> GetAirbnbCards(AirbnbDto airbnbDto);
    }
}
