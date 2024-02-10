﻿using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;

namespace Airbnb.Repository.Interface
{
    public interface IAirbnbRepository : IGenericRepository<Model.Models.Airbnb>
    {
        Task<IEnumerable<string>> GetNames();

        Task<IEnumerable<CategoryResponseDTO>> GetCategories();

        Task<AirbnbResponseDTO> GetAirbnbCards(AirbnbRequestDTO airbnbRequestDTO);

        Task<AirbnbDetailResponseDTO> GetAirbnbDetails(Guid airbnbId);
    }
}
