using MongoDB.Bson;
using MongoDB.Driver;

namespace MoodPlus.Services
{
    public class MoodRepository<T> : IRepository<T>
    {

        private readonly IMongoCollection<T> _collection;

        public MoodRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetByIdAsync(int id) =>
            await _collection.Find(Builders<T>.Filter.Eq("id", id)).FirstOrDefaultAsync();

        public async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(int id, T entity) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("id", id), entity);

        public async Task DeleteAsync(int id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("id", id));

    }
}
