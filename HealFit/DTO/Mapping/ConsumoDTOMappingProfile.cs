using AutoMapper;
using HealFit.Models;

namespace HealFit.DTO.Mapping;
public class ConsumoDTOMappingProfile : Profile{
    public ConsumoDTOMappingProfile() {

        CreateMap<Consumo, ConsumoDTO>().ReverseMap();

    }
}
