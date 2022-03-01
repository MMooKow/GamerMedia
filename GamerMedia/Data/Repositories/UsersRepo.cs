using GamerMedia.Data.Entities;
using GamerMedia.Data.Interfaces;
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

        public async Task<User> CreateUserAsync(User user)
        {
            if(user != null)
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return user; 
            }else throw new ArgumentNullException(nameof(user));

        }

        public async Task<string> DeleteUserAsync(int id)
        {
            User user = await _context.Users.FindAsync(id) ?? throw new ArgumentException();
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return "User deleted";
            }
            else throw new ArgumentException("User not found");
        }

        public async Task<User> GetUserAsync(int id)
        {
            User user = await _context.Users.FindAsync(id) ?? throw new ArgumentException();
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
                throw new NullReferenceException("No users found");
            }
            else return users;

        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            User updatedUser = await _context.Users.FindAsync(id) ?? throw new ArgumentException();
            if(user != null)
            {
                updatedUser.Username = user.Username;
                updatedUser.LastName = user.LastName;
                updatedUser.FirstName = user.FirstName;

                await _context.SaveChangesAsync();
                return updatedUser;
            }else throw new ArgumentException(nameof(user));
            
        }

        public async Task<User> DelistUserAsync(int id)
        {
            User user = await _context.Users
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync() ?? throw new ArgumentException();
            if (user == null)
            {
                return null;
            }
            if (user.IsActive == 0)
            {
                return user;
            }
            user.IsActive = 0;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
