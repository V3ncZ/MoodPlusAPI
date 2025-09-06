using MoodPlus.Model;

namespace MoodPlus.Repositories
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(string id);
        Task Create(User entity);
        Task Update(string id, User entity);
        Task Delete(string id);
    }
}
