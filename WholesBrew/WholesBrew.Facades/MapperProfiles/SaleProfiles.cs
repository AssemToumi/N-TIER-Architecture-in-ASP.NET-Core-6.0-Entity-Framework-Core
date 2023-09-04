using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class SaleProfiles : Profile
{
    public SaleProfiles()
    {
        CreateMap<SaleEntity, SaleDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Wholesaler, opt => opt.MapFrom(src => src.Wholesaler)) // Include Wholesaler for GET
           .ForMember(dest => dest.Beer, opt => opt.MapFrom(src => src.Beer)); // Include Beer for GET

        CreateMap<SaleDTO, SaleEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Wholesaler, opt => opt.Ignore()) // Ignore Wholesaler for POST
            .ForMember(dest => dest.Beer, opt => opt.Ignore()) // Ignore Beer for POST
            .ForMember(dest => dest.WholesalerId, opt => opt.MapFrom(src => src.Wholesaler.Id)) // Map Wholesaler's Id for POST
            .ForMember(dest => dest.BeerId, opt => opt.MapFrom(src => src.Beer.Id)); // Map Beer's Id for POST
    }
}
