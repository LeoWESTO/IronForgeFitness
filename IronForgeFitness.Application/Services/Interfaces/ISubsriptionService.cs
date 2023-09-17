using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface ISubsriptionService
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int page, int itemsPerPage);
        Task<Subscription> GetSubscriptionAsync(Guid id);
        Task OpenSubscriptionAsync(Subscription subscription);
        Task UpdateSubscriptionAsync(Subscription subscription);
        Task CloseSubscriptionAsync(Guid id);
        Task<int> TotalCount();
    }
}
