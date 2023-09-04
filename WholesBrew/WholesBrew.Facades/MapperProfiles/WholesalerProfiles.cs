using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class WholesalerProfiles : Profile
{
    public WholesalerProfiles()
    {
        CreateMap<WholesalerEntity, WholesalerDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)); // Include Wholesaler Id for GET

        CreateMap<WholesalerDTO, WholesalerEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Wholesaler Id for POST
    }
}
