using AutoMapper;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.MapperProfiles;

public class QuoteRequestProfiles : Profile
{
    public QuoteRequestProfiles()
    {
        CreateMap<QuoteRequestEntity, QuoteRequestDTO>().ReverseMap();
    }
}

