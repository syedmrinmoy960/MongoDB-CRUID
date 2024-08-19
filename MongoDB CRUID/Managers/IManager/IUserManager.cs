using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Managers.IManager
{
    public interface IUserManager
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(string id, User user);
        Task DeleteUserAsync(string id);
    }
}
