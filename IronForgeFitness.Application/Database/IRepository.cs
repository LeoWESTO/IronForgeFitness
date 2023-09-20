using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Application.Database
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByPageAsync(int page, int itemsPerPage);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<int> CountAsync();
    }
}
