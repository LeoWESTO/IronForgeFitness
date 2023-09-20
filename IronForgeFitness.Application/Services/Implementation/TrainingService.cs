using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Implementation
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepository<Training> _trainingRepository;

        public TrainingService(IRepository<Training> trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }
        public async Task DeleteTrainingAsync(Guid id)
        {
            await _trainingRepository.DeleteAsync(id);
        }

        public async Task<Training> GetTrainingAsync(Guid id)
        {
            return await _trainingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Training>> GetTrainingsAsync(int page, int itemsPerPage)
        {
            return await _trainingRepository.GetByPageAsync(page, itemsPerPage);
        }

        public async Task ScheduleTrainingAsync(Training training)
        {
            await _trainingRepository.AddAsync(training);
        }

        public async Task<int> TotalCount()
        {
            return await _trainingRepository.CountAsync();
        }

        public async Task UpdateTrainingAsync(Training training)
        {
            await _trainingRepository.UpdateAsync(training);
        }
    }
}
