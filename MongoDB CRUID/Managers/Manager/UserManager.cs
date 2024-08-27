using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;

namespace MongoDB_CRUID.Managers.Manager
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<adminusers>> GetAllUsersAsync()
        {
            return (List<adminusers>)await _userRepository.GetAllAsync();
        }

        public async Task<adminusers> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddUserAsync(adminusers user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(string id, adminusers user)
        {
            await _userRepository.UpdateAsync(id, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
        }

    }
}
