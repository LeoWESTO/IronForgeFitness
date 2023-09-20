using IronForgeFitness.Application.Database;
using IronForgeFitness.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace IronForgeFitness.Infrastructure.Database.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public SqlRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<IEnumerable<T>> GetByPageAsync(int page, int itemsPerPage)
        {
            return await _context.Set<T>().Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
