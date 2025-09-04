using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Model;
using MoodPlus.Services;

namespace MoodPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userService.Create(user);
            return Ok(user);
        }
    }
}
