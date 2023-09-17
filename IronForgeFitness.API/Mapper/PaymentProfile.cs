using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities.Transactions;

namespace IronForgeFitness.API.Mapper;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentGet>()
            .ReverseMap();
        CreateMap<Payment, PaymentPost>()
            .ReverseMap();
        CreateMap<Payment, PaymentPut>()
            .ReverseMap();
    }
}
