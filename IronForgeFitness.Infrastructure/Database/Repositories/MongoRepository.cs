using IronForgeFitness.Application.Database;
using IronForgeFitness.Domain.Abstractions;
using MongoDB.Driver;

namespace IronForgeFitness.Infrastructure.Database.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _db;

        public MongoRepository(MongoClient client)
        {
            _db = client.GetDatabase("ironforge").GetCollection<T>(typeof(T).FullName);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _db.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            if (entity != null)
            {
                await _db.InsertOneAsync(entity);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                var filter = Builders<T>.Filter.Eq("_id", entity.Id);
                await _db.ReplaceOneAsync(filter, entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _db.DeleteOneAsync(filter);
        }

        public Task<IEnumerable<T>> GetByPage(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
