using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;

namespace MongoDB_CRUID.Repositories.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IMongoCollection<adminusers> _usersCollection;

        public LoginRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<adminusers>(mongoDBSettings.Value.UsersCollectionName);
        }
        public async Task<adminusers> GetUserByEmailAsync(string email)
        {
            var filter = Builders<adminusers>.Filter.Eq("email", email);
        

            return await _usersCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
