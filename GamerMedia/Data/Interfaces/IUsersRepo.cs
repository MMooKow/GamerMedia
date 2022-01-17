using GamerMedia.Data.Entities;

namespace GamerMedia.Data.Interfaces
{
    public interface IUsersRepo
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<string> DeleteUser(int id);

        Task<User> CreateUser(User user);

        Task<User> UpdateUser(User user, int id);
    }

}
