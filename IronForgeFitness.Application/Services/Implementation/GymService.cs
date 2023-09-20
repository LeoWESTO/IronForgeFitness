using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Implementation
{
    public class GymService : IGymService
    {
        private readonly IRepository<Gym> _gymRepository;

        public GymService(IRepository<Gym> gymRepository)
        {
            _gymRepository = gymRepository;
        }

        public async Task CloseGymAsync(Guid id)
        {
            await _gymRepository.DeleteAsync(id);
        }

        public async Task<Gym> GetGymAsync(Guid id)
        {
            return await _gymRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Gym>> GetGymsAsync(int page, int itemsPerPage)
        {
            return await _gymRepository.GetByPageAsync(page, itemsPerPage);
        }

        public async Task<IEnumerable<Gym>> GetGymsAsync()
        {
            return await _gymRepository.GetAllAsync();
        }

        public async Task OpenGymAsync(Gym gym)
        {
            await _gymRepository.AddAsync(gym);
        }

        public async Task<int> TotalCount()
        {
            return await _gymRepository.CountAsync();
        }

        public async Task UpdateGymAsync(Gym gym)
        {
            await _gymRepository.UpdateAsync(gym);
        }
    }
}
