using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper;

public class GymProfile : Profile
{
    public GymProfile()
    {
        CreateMap<Gym, GymResponse>()
            .ReverseMap();
        CreateMap<Gym, GymRequest>()
            .ReverseMap();
    }
}
