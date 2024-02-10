using Airbnb.Model.Models;
using Airbnb.Repository.Interface;
using Airbnb.Service.Interface;

namespace Airbnb.Service.Implementation
{
    public class AirbnbCategoryService : BaseService<AirbnbCategory>, IAirbnbCategoryService
    {
        public AirbnbCategoryService(IAirbnbCategoryRepository airbnbCategoryRepository) : base(airbnbCategoryRepository) { }
    }
}
