using MongoDB.Bson;
using NPOI.SS.Formula.Functions;

namespace MoodPlus.Services
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(ObjectId id);
        Task CreateAsync(T entity);
        Task UpdateAsync(ObjectId id, T entity);
        Task DeleteAsync(ObjectId id);
    }
}
