using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<List<adminusers>> GetAllAsync();
        Task<adminusers> GetByIdAsync(string id);
        Task AddAsync(adminusers user);
        Task UpdateAsync(string id, adminusers user);
        Task DeleteAsync(string id);
    }
}
