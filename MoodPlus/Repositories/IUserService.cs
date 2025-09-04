using MoodPlus.Model;

namespace MoodPlus.Repositories
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task Create(User entity);
        Task Update(int id, User entity);
        Task Delete(int id);
    }
}
