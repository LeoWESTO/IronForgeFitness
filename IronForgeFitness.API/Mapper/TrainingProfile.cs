using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<Training, TrainingResponse>()
            .ReverseMap();
            CreateMap<Training, TrainingRequest>()
                .ReverseMap();
        }
    }
}
