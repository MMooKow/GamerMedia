using GamerMedia.Data.Entities;
using GamerMedia.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data.Repositories
{
    public class CommentRepo : ICommentRepo
    {
        private readonly DataContext _context;

        public CommentRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            if (comment != null)
            {
                await _context.AddAsync(comment);
                await _context.SaveChangesAsync();
                return comment;
            }
            else throw new ArgumentNullException(nameof(comment));

        }

        public async Task<string> DeleteCommentAsync(int id)
        {
            Comment comment = await _context.Comment.FindAsync(id) ?? throw new ArgumentException();
            if (comment != null)
            {
                _context.Remove(comment);
                await _context.SaveChangesAsync();
                return "Comment deleted";
            }
            else throw new ArgumentException("Comment not found");
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            Comment comment = await _context.Comment.FindAsync(id) ?? throw new ArgumentException();
            if (comment != null)
            {
                return comment;
            }
            else throw new ArgumentException($"Comment of id {id} not found");
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            List<Comment> comments = await _context.Comment
                .Where(x => x.IsActive == true)
                .ToListAsync();
            if (comments == null)
            {
                throw new NullReferenceException("No comments found");
            }
            else return comments;

        }

        public async Task<Comment> UpdateCommentAsync(int id, Comment comment)
        {
            Comment updatedComment = await _context.Comment.FindAsync(id) ?? throw new ArgumentException();
            if (comment != null)
            {
                updatedComment.Body = comment.Body;

                await _context.SaveChangesAsync();
                return updatedComment;
            }
            else throw new ArgumentException(nameof(comment));

        }

        public async Task<Comment> DelistCommentAsync(int id)
        {
            Comment comment = await _context.Comment
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync() ?? throw new ArgumentException();
            if (comment == null)
            {
                return null;
            }
            if(comment.IsActive == false)
            {
                return comment;
            }
            comment.IsActive = false;
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
