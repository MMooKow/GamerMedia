using Microsoft.AspNetCore.Mvc;
using GamerMedia.Data.Interfaces;
using GamerMedia.Data.Repositories;
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
            else
            {
                return Ok(user);
            }
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
            else
            {
                return Ok(user);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(User user)
        {
            await _usersRepo.CreateUser(user);
            if(user == null)
            {
                return NotFound(user.Id);
            }
            else
            {
                return Ok(user);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            string result = await _usersRepo.DeleteUser(id);
            if(result == "Owner not found")
            {
                return NotFound($"Owner of id {id} was not found");
            }else
            {
                return Ok("Success!");
            }

        }
    }
}
