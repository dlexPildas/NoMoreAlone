using AutoMapper;
using NoMoreAlone.Api.Dtos.Carona;
using NoMoreAlone.Domain.Models;

namespace NoMoreAlone.Api.AutoMapper
{
    public class CaronaMapper : Profile
    {
        public CaronaMapper()
        {
            CreateMap<Carona, CaronaCreateDto>().ReverseMap();
            CreateMap<Carona, CaronaReadDto>()
                .ForMember(dest => dest.Tipo, act => act.MapFrom(src => src.Tipo.ToString()))
                .ReverseMap();
        }
    }
}