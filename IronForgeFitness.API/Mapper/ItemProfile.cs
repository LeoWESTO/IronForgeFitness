using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemResponse>()
            .ReverseMap();
        CreateMap<Item, ItemRequest>()
            .ReverseMap();
    }
}
