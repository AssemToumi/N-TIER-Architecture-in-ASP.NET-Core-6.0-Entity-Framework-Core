using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class BeerProfiles : Profile
{
    public BeerProfiles()
    {
        CreateMap<BeerEntity, BeerDTO>()
             .ForMember(dest => dest.Brewer, opt => opt.MapFrom(src => src.Brewer)); // Include Brewer for GET

        CreateMap<BeerDTO, BeerEntity>()
            .ForMember(dest => dest.Brewer, opt => opt.Ignore()) // Ignore Brewer for POST
            .ForMember(dest => dest.BrewerId, opt => opt.MapFrom(src => src.Brewer.Id)); // Map Brewer's Id for POST
    }
}
