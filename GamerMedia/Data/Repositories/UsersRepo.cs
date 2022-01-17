using GamerMedia.Data.Entities;
using GamerMedia.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private readonly DataContext _context;

        public UsersRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            if(user != null)
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return user; 
            }else throw new ArgumentNullException(nameof(user));

        }

        public async Task<string> DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return "Owner deleted";
            }
            else throw new ArgumentException("Owner not found");
        }

        public async Task<User> GetUserAsync(int id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                return user;
            }
            else throw new ArgumentException($"User of id {id} not found");
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = await _context.Users.ToListAsync();
            if (users == null)
            {
                throw new NullReferenceException("No owners found");
            }
            else return users;

        }

        public Task<User> UpdateUser(User user, int id)
        {
            throw new NotImplementedException();
        }
    }
}
