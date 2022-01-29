using GamerMedia.Data.Entities;

namespace GamerMedia.Data.Interfaces
{
    public interface ICommentRepo
    {
        Task<List<Comment>> GetCommentsAsync();

        Task<Comment> GetCommentAsync(int id);

        Task<string> DeleteCommentAsync(int id);

        Task<Comment> CreateCommentAsync(Comment comment);

        Task<Comment> UpdateCommentAsync(int id, Comment comment);
    }
}
