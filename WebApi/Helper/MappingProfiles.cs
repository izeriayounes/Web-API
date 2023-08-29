using AutoMapper;
using WebApi.Models;
using WebApi.Dto;

namespace WebApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Enfant, EnfantDto>().ReverseMap();
            CreateMap<Famille, FamilleDto>().ReverseMap();
            CreateMap<Parrain, ParrainDto>().ReverseMap();
            CreateMap<Parrainage, ParrainageDto>().ReverseMap();
        }
    }

}

