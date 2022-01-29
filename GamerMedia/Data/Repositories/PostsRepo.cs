using GamerMedia.Data.Entities;
using GamerMedia.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data.Repositories
{
    public class PostsRepo : IPostsRepo
    {
        private readonly DataContext _context;

        public PostsRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            if (post != null)
            {
                await _context.AddAsync(post);
                await _context.SaveChangesAsync();
                return post;
            }
            else throw new ArgumentNullException(nameof(post));

        }

        public async Task<string> DeletePostAsync(int id)
        {
            Post post = await _context.Posts.FindAsync(id) ?? throw new ArgumentException();
            if (post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
                return "Post deleted";
            }
            else throw new ArgumentException("Post not found");
        }

        public async Task<Post> GetPostAsync(int id)
        {
            Post post = await _context.Posts.FindAsync(id) ?? throw new ArgumentException();
            if (post != null)
            {
                return post;
            }
            else throw new ArgumentException($"Post of id {id} not found");
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            if (posts == null)
            {
                throw new NullReferenceException("No posts found");
            }
            else return posts;

        }

        public async Task<Post> UpdatePostAsync(int id, Post post)
        {
            Post updatedPost = await _context.Posts.FindAsync(id) ?? throw new ArgumentException();
            if (post != null)
            {
                updatedPost.Title = post.Title;
                updatedPost.Body = post.Body;

                await _context.SaveChangesAsync();
                return updatedPost;
            }
            else throw new ArgumentException(nameof(post));

        }
    }
}
