using AutoMapper;
using WholesBrew.Contracts.DataTransferObjects;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class RestrictionProfiles : Profile
{
    public RestrictionProfiles()
    {
        CreateMap<RestrictionEntity, RestrictionDTO>()
        .ForMember(dest => dest.Wholesaler, opt => opt.MapFrom(src => src.Wholesaler)) // Include Wholesaler for GET
        .ForMember(dest => dest.Beer, opt => opt.MapFrom(src => src.Beer)); // Include Beer for GET

        CreateMap<RestrictionDTO, RestrictionEntity>()
            .ForMember(dest => dest.Wholesaler, opt => opt.Ignore()) // Ignore Wholesaler for POST
            .ForMember(dest => dest.Beer, opt => opt.Ignore()) // Ignore Beer for POST
            .ForMember(dest => dest.WholesalerId, opt => opt.MapFrom(src => src.Wholesaler.Id)) // Map Wholesaler's Id for POST
            .ForMember(dest => dest.BeerId, opt => opt.MapFrom(src => src.Beer.Id)); // Map Beer's Id for POST
    }
}
