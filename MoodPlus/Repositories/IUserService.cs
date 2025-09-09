using MongoDB.Bson;
using MoodPlus.Model;

namespace MoodPlus.Repositories
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(ObjectId id);
        Task Create(User entity);
        Task Update(ObjectId id, User entity);
        Task Delete(ObjectId id);
    }
}
