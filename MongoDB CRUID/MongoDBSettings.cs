using MongoDB.Bson;
namespace MongoDB_CRUID
{
    public class MongoDBSettings
    {
        // The MongoDB connection string, typically includes the server address and credentials
        public string ConnectionString { get; set; } = string.Empty;

        // The name of the MongoDB database to connect to
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;
    }
}
