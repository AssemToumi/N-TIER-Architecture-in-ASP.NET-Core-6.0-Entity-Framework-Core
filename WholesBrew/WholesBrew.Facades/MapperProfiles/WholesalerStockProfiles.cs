using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class WholesalerStockProfiles : Profile
{
    public WholesalerStockProfiles()
    {
        CreateMap<WholesalerStockEntity, WholesalerStockDTO>()
            .ForMember(dest => dest.Beer, opt => opt.MapFrom(src => src.Beer)) // Include Beer for GET
            .ForMember(dest => dest.Wholesaler, opt => opt.MapFrom(src => src.Wholesaler)); // Include Wholesaler for GET

        CreateMap<WholesalerStockDTO, WholesalerStockEntity>()
            .ForMember(dest => dest.Beer, opt => opt.Ignore()) // Ignore Beer for POST
            .ForMember(dest => dest.Wholesaler, opt => opt.Ignore()) // Ignore Wholesaler for POST
            .ForMember(dest => dest.BeerId, opt => opt.MapFrom(src => src.Beer.Id)) // Map Beer's Id for POST
            .ForMember(dest => dest.WholesalerId, opt => opt.MapFrom(src => src.Wholesaler.Id)); // Map Wholesaler's Id for POST
    }
}
