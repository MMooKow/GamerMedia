using GamerMedia.Data.Entities;

namespace GamerMedia.Data.Interfaces
{
    public interface IUsersRepo
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<string> DeleteUser(int id);

        Task<User> CreateUserAsync(User user);

        Task<User> UpdateUserAsync(int id, User user);
    }

}
