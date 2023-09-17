using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountResponse>()
            .ReverseMap();
        CreateMap<Account, AccountRequest>()
            .ReverseMap();
    }
}
