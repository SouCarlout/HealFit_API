using AutoMapper;
using HealFit.DTO.Request;
using HealFit.DTO.Rsp;
using HealFit.Models;

namespace HealFit.DTO.Mapping; 
public class UsuarioDTOMappingProfile : Profile{

    public UsuarioDTOMappingProfile() {

        CreateMap<Usuario, LoginDTO>().ReverseMap();
        CreateMap<Usuario, LoginDTORequest>().ReverseMap();
        CreateMap<Usuario, LoginDTOResponse>().ReverseMap();

    }
}
