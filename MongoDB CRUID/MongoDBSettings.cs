using MongoDB.Bson;
namespace MongoDB_CRUID
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string UsersCollectionName { get; set; } = string.Empty;
        public string LogsCollectionName { get; set; } = string.Empty; 
          public string Userscollection { get; set; } = string.Empty;
    }
}
