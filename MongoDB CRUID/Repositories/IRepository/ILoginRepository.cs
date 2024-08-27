using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Repositories.IRepository
{
    public interface ILoginRepository
    {
        Task<adminusers> GetUserByEmailAsync(string email);
    }
}
