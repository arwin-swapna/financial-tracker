using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AccountDto, Account>()
            .ForMember(dest => dest.InstitutionName, opt => opt.MapFrom(src => src.Institution.Name));
        }
    }
}