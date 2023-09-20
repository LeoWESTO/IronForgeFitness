using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionResponse>()
            .ReverseMap();
        CreateMap<Transaction, TransactionRequest>()
            .ReverseMap();
    }
}
