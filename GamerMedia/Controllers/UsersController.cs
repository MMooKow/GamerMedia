using Microsoft.AspNetCore.Mvc;
using GamerMedia.Data.Interfaces;
using GamerMedia.Data.Entities;

namespace GamerMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _usersRepo;
        public UsersController(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult> GetUsersAsync()
        {
            List<User> user = await _usersRepo.GetUsersAsync();
            if(user == null)
            {
                return NotFound();
            }
                return Ok(user);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserAsync(int id)
        {
            User user = await _usersRepo.GetUserAsync(id);
            if(user == null)
            {
                return NotFound(id);
            }
                return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] User user)
        {
            await _usersRepo.CreateUserAsync(user);
            if(user == null)
            {
                return NotFound(user.Id);
            }
                return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(int id,[FromBody] User user)
        {
            User updatedUser = await _usersRepo.UpdateUserAsync(id, user);
            if(updatedUser == null)
            {
                return BadRequest("User not found.");
            }
                return Ok(updatedUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            string result = await _usersRepo.DeleteUserAsync(id);
            if(result == "User not found")
            {
                return NotFound($"User of id {id} was not found");
            }
                return Ok("Success!");
        }

        // PATCH0 api/<CommentController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> DelistUserAsync(int id)
        {
            User delistResult = await _usersRepo.DelistUserAsync(id);
            if (delistResult == null)
            {
                return BadRequest(delistResult);
            }
            return Ok(delistResult);
        }
    }
}
