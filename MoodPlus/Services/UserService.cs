using MongoDB.Bson;
using MoodPlus.Data;
using MoodPlus.Model;
using MoodPlus.Repositories;
using NPOI.SS.Formula.Functions;

namespace MoodPlus.Services
{
    public class UserService : IUserService
    {

        private readonly DAO<User> _repository;

        public UserService(DAO<User> repository)
        {
            _repository = repository;
        }

        public async Task Create(User user)
        {
            await _repository.CreateAsync(user);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task Update(int id, User entity)
        {
            return _repository.UpdateAsync(id, entity);
        }
    }
}
