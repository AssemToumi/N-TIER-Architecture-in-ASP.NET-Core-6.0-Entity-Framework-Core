using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class OrderResponseProfiles : Profile
{
    public OrderResponseProfiles()
    {
        CreateMap<OrderResponseEntity, OrderResponseDTO>()
            .ForMember(dest => dest.Beer, opt => opt.MapFrom(src => src.Beer)); // Include Brewer for GET

        CreateMap<OrderResponseDTO, OrderResponseEntity>()
            .ForMember(dest => dest.Beer, opt => opt.Ignore()) // Include Brewer for GET
            .ForMember(dest => dest.BeerId, opt => opt.MapFrom(src => src.Beer.Id)); // Map Brewer's Id for POST
    }
}
