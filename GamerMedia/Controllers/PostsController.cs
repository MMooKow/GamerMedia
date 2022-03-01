using Microsoft.AspNetCore.Mvc;
using GamerMedia.Data.Entities;
using GamerMedia.Data.Interfaces;

namespace GamerMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepo _postRepo;
        public PostsController(IPostsRepo postRepo)
        {
            _postRepo = postRepo;
        }
        // GET: api/<PostsController>
        [HttpGet]
        public async Task<ActionResult> GetPostsAsync()
        {
            List<Post> postList = await _postRepo.GetPostsAsync();
            if(postList == null)
            {
                return NotFound("No users found");
            }
            return Ok(postList);
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPostAsync(int id)
        {
            Post post = await _postRepo.GetPostAsync(id);
            if(post == null)
            {
                return BadRequest(id);
            }
                return Ok(post);
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<ActionResult> CreatePostAsync([FromBody] Post post)
        {
            Post createdPost = await _postRepo.CreatePostAsync(post);
            if(createdPost == null)
            {
                return BadRequest(createdPost);
            }
                return Ok(createdPost);

        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostAsync(int id, [FromBody] Post post)
        {
            Post updatedPost = await _postRepo.UpdatePostAsync(id, post);
            if(updatedPost == null)
            {
                return BadRequest(updatedPost);
            }
                return Ok(updatedPost);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostAsync(int id)
        {
            string res = await _postRepo.DeletePostAsync(id);
            if(res == "Post not found")
            {
                return BadRequest($"Post not found with id {id}");
            }
                return Ok(res);
        }

        // PATCH api/<CommentController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> DelistPostAsync(int id)
        {
            Post delistResult = await _postRepo.DelistPostAsync(id);
            if (delistResult == null)
            {
                return BadRequest(delistResult);
            }
            return Ok(delistResult);
        }
    }
}
