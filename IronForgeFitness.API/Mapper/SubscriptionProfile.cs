using AutoMapper;
using IronForgeFitness.API.DTOs;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.API.Mapper;

public class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<Subscription, SubscriptionResponse>()
            .ReverseMap();
        CreateMap<Subscription, SubscriptionRequest>()
            .ReverseMap();
    }
}
