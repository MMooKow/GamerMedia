using Microsoft.AspNetCore.Mvc;
using GamerMedia.Data.Interfaces;
using GamerMedia.Data.Entities;

namespace GamerMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepo _commentRepo;
        public CommentController(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult> GetCommentsAsync()
        {
            List<Comment> comments = await _commentRepo.GetCommentsAsync();
            if(comments == null)
            {
                return NotFound("No comments found");
            }
                return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetComment(int id)
        {
            Comment comment = await _commentRepo.GetCommentAsync(id);
            if(comment == null)
            {
                return NotFound($"No comment with id {id} was found.");
            }
                return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult> CreateCommentAsync([FromBody] Comment comment)
        {
            Comment createdCom = await _commentRepo.CreateCommentAsync(comment);
            if (createdCom == null)
            {
                return BadRequest("Unable to create comment. Input error");
            }
                return Ok(createdCom);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommentAsync(int id, [FromBody] Comment comment)
        {
            Comment updatedCom = await _commentRepo.UpdateCommentAsync(id, comment);
            if (updatedCom == null)
            {
                return BadRequest($"Update with id {id} was not sucessful");
            }
            return Ok(updatedCom);
        }

        // PATCH api/<CommentController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> DeleteCommentAsync(int id)
        {
            Comment delistResult = await _commentRepo.DelistCommentAsync(id);
            if (delistResult == null)
            {
                return BadRequest(delistResult);
            }
            return Ok(delistResult);
        }

    }
}
