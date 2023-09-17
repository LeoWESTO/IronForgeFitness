using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeGet>()
            .ReverseMap();
        CreateMap<Employee, EmployeePost>()
            .ReverseMap();
        CreateMap<Employee, EmployeePut>()
            .ReverseMap();
    }
}
