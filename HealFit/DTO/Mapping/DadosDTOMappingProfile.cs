using AutoMapper;
using HealFit.Models;

namespace HealFit.DTO.Mapping; 
public class DadosDTOMappingProfile : Profile {

    public DadosDTOMappingProfile() {

        CreateMap<DadosPessoais, DadosDTO>().ReverseMap();
        CreateMap<DadosPessoais, LoginDTO>().ReverseMap();

    }
}
