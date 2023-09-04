using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class QuoteResponseProfiles : Profile
{
    public QuoteResponseProfiles()
    {
        CreateMap<QuoteResponseEntity, QuoteResponseDTO>()
            .ForMember(dest => dest.Wholesaler, opt => opt.MapFrom(src => src.Wholesaler)); // Include Wholesaler for GET

        CreateMap<QuoteResponseDTO, QuoteResponseEntity>()
            .ForMember(dest => dest.Wholesaler, opt => opt.Ignore()) // Include Brewer for GET
            .ForMember(dest => dest.WholesalerId, opt => opt.MapFrom(src => src.Wholesaler.Id)); // Map Wholesaler's Id for POST
    }
}

