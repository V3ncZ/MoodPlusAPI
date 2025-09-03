using MongoDB.Bson;
using MongoDB.Driver;
using MoodPlus.Services;

namespace MoodPlus.Data
{
    public class DAO<T> : IRepository<T>
    {

        // Represent a Mongo Collection in order to allow us to use the CRUD commands
        private readonly IMongoCollection<T> _collection;

        // Class constructor that creates a instance of the collection accordingly to the generic type
        public DAO(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        // Method that gets all the data from the Collection
        public async Task<List<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        // Method that gets a specific document based on the provided id
        public async Task<T?> GetByIdAsync(int id) =>
            await _collection.Find(Builders<T>.Filter.Eq("id", id)).FirstOrDefaultAsync();

        // Creates a document based on the provided entity
        public async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        // Updates the document based on the provided id
        public async Task UpdateAsync(int id, T entity) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("id", id), entity);

        // Deletes the document based on the provided id
        public async Task DeleteAsync(int id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("id", id));

    }
}
