using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MoodPlus.Model;
using MoodPlus.Repositories;
using MoodPlus.Requests;
using MoodPlus.Responses;
using MoodPlus.Services;

namespace MoodPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            var user = new User
            {
                Name = userRequest.name,
                Email = userRequest.email
            };

            await _userService.Create(user);

            var response = new UserResponse(
                user.Id.ToString(),
                user.Name,
                user.Email
            );

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var users = await _userService.GetAll();

            var response = users.Select(u => new UserResponse(
                u.Id.ToString(),
                u.Name,
                u.Email
            )).ToList();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, [FromBody] UserRequest userRequest)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                // Se a conversão falhar, retorna um erro de requisição inválida
                return BadRequest("ID inválido. O ID deve ser um ObjectId de 24 caracteres.");
            }

            var userToFind = await _userService.GetById(objectId);

            if (userToFind is not null)
            {
                userToFind.Name = userRequest.name;
                userToFind.Email = userRequest.email;

                await _userService.Update(objectId, userToFind);

                var newUserResponse = new UserResponse(
                    userToFind.Id.ToString(),
                    userToFind.Name,
                    userToFind.Email
                );

                return Ok(newUserResponse)  ;
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {

            if (!ObjectId.TryParse(id, out var objectId))
            {
                // Se a conversão falhar, retorna um erro de requisição inválida
                return BadRequest("ID inválido. O ID deve ser um ObjectId de 24 caracteres.");
            }

            var userToDelete = await _userService.GetById(objectId);

            if (userToDelete is not null)
            {
                await _userService.Delete(objectId);
                return Ok();
            }

            return NotFound();
        }
    }
}
