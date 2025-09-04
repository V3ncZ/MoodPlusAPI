using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Model;

namespace MoodPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MongoDbConnection _connection;
        private readonly DAO<User> _dao;

        // Dependecy injection
        public UserController(MongoDbConnection connection, DAO<User> dao)
        {
            _connection = connection;
            _dao = dao;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _dao.CreateAsync(user);
            return Ok(user);
        }
    }
}
