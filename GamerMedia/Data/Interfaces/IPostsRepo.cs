using GamerMedia.Data.Entities;

namespace GamerMedia.Data.Interfaces
{
    public interface IPostsRepo
    {
        Task<List<Post>> GetPostsAsync();

        Task<Post> GetPostAsync(int id);

        Task<string> DeletePostAsync(int id);

        Task<Post> CreatePostAsync(Post post);

        Task<Post> UpdatePostAsync(int id, Post post);
}
