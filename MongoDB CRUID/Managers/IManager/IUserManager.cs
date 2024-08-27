using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Managers.IManager
{
    public interface IUserManager
    {
        Task<List<adminusers>> GetAllUsersAsync();
        Task<adminusers> GetUserByIdAsync(string id);
        Task AddUserAsync(adminusers user);
        Task UpdateUserAsync(string id, adminusers user);
        Task DeleteUserAsync(string id);
    }
}
