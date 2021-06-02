using AutoMapper;
using HealthCatalyst.API.DTOs;
using HealthCatalyst.API.Models;

namespace HealthCatalyst.API.MappingProfiles
{
    public class PeopleMappingProfile : Profile
    {
        public PeopleMappingProfile()
        {
            //Source -> Destination
            CreateMap<Person, PersonReadDTO>();
            CreateMap<PersonCreateDTO, Person>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}