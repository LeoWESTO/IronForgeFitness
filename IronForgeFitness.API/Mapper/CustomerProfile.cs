using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerGet>()
            .ReverseMap();
        CreateMap<Customer, CustomerPost>()
            .ReverseMap();
        CreateMap<Customer, CustomerPut>()
            .ReverseMap();
    }
}