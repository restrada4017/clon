using ADN.Application.Features.Adns.Commands.CreateAdn;
using ADN.Application.Features.Adns.Commands.UpdateAdn;
using ADN.Application.Features.Adns.Queries;
using ADN.Domain.Entities;
using AutoMapper;

namespace ADN.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Adn, AdnVm>().ReverseMap();
            CreateMap<Adn, CreateAdnCommand>().ReverseMap();
            CreateMap<Adn, UpdateAdnCommand>().ReverseMap();
        }
    }
}
