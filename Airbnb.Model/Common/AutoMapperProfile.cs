using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;
using Airbnb.Model.Models;
using AutoMapper;

namespace Airbnb.Model.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserProfileResponseDTO>()
                .ForMember(dest => dest.UserId, src => src.MapFrom(map => map.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(map => map.FirstName));

            CreateMap<SignupRequestDTO, ApplicationUser>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(map => map.Email));

            CreateMap<ApplicationUser, VerifyResetPasswordResponseDTO>()
                .ForMember(dest => dest.UserId, src => src.MapFrom(map => map.Id));

            CreateMap<AirbnbCategory, CategoryResponseDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(map => map.AirbnbCategoryId));
        }
    }
}
