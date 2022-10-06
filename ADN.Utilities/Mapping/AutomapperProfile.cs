
using ADN.Domain.Entities;
using ADN.Shared.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Utilities.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Adn, AdnDto>().ReverseMap();
            CreateMap<Estadistica, EstadisticaDto>().ReverseMap();
        }
    }
}
