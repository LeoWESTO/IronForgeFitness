using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceResponse>()
            .ReverseMap();
            CreateMap<Service, ServiceRequest>()
                .ReverseMap();
        }
    }
}
