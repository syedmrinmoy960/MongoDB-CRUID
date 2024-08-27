using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;

namespace MongoDB_CRUID.Repositories.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IMongoCollection<adminusers> _usersCollection;

        public UserRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
      
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            //_usersCollection = mongoDatabase.GetCollection<Users>(mongoDBSettings.Value.CollectionName);
            _usersCollection = mongoDatabase.GetCollection<adminusers>(mongoDBSettings.Value.UsersCollectionName);
        }

        public async Task<List<adminusers>> GetAllAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<adminusers> GetByIdAsync(string id)
        {
            return await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(adminusers user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(string id, adminusers user)
        {
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, user);
        }

        public async Task DeleteAsync(string id)
        {
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
        }

    }
}
