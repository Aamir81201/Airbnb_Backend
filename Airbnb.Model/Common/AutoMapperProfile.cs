using Airbnb.Model.DTO.Response;
using Airbnb.Model.Models;

namespace Airbnb.Model.Common
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AirbnbCategory, CategoryResponseDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(map => map.AirbnbCategoryId));

            CreateMap<ApplicationUser, UserProfileResponseDTO>()
                .ForMember(dest => dest.UserId, src => src.MapFrom(map => map.Id));
        }
    }
}
