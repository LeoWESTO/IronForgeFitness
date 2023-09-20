using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface IGymService
    {
        Task<IEnumerable<Gym>> GetGymsAsync();
        Task<IEnumerable<Gym>> GetGymsAsync(int page, int itemsPerPage);
        Task<Gym> GetGymAsync(Guid id);
        Task OpenGymAsync(Gym gym);
        Task UpdateGymAsync(Gym gym);
        Task CloseGymAsync(Guid id);
        Task<int> TotalCount();
    }
}
