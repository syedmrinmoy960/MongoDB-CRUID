using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB_CRUID.Models
{
    public class users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        public int UserId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
