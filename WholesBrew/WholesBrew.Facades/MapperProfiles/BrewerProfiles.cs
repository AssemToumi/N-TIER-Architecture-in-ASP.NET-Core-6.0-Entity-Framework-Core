using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class BrewerProfiles : Profile
{
    public BrewerProfiles()
    {
        CreateMap<BrewerEntity, BrewerDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)); // Include Brewer Id for GET

        CreateMap<BrewerDTO, BrewerEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Brewer Id for POST
    }
}
