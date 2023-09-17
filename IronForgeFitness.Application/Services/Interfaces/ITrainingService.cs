using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<Training>> GetTrainingsAsync(int page, int itemsPerPage);
        Task<Training> GetTrainingAsync(Guid id);
        Task ScheduleTrainingAsync(Training training);
        Task UpdateTrainingAsync(Training training);
        Task DeleteTrainingAsync(Guid id);
        Task<int> TotalCount();
    }
}
