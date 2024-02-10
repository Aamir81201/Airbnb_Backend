using Airbnb.Model.DTO.Response;
using Airbnb.Model.Models;

namespace Airbnb.Model.Common
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AirbnbCategory, CategoryResponseDTO>()
                .ForMember(dest => dest.Id, cd => cd.MapFrom(map => map.AirbnbCategoryId));
        }
    }
}
