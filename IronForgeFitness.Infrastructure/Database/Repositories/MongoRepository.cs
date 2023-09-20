using IronForgeFitness.Application.Database;
using IronForgeFitness.Domain.Abstractions;
using MongoDB.Driver;

namespace IronForgeFitness.Infrastructure.Database.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            if (entity != null)
            {
                await _collection.InsertOneAsync(entity);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                var filter = Builders<T>.Filter.Eq("_id", entity.Id);
                await _collection.ReplaceOneAsync(filter, entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<T>> GetByPageAsync(int page, int itemsPerPage)
        {
            return (await _collection.Find("{}").ToListAsync())
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);
        }

        public async Task<int> CountAsync()
        {
            return (int)await _collection.CountDocumentsAsync("{}");
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return (await _collection.FindAsync("{}")).ToList();
        }
    }
}
