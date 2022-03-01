using GamerMedia.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamerMedia.Data.Interfaces
{
    public interface IUsersRepo
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<string> DeleteUserAsync(int id);

        Task<User> CreateUserAsync(User user);

        Task<User> UpdateUserAsync(int id,[FromBody] User user);

        Task<User> DelistUserAsync(int id);
    }

}
