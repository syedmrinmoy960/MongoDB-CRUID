using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDB_CRUID.Models
{
    public class adminusers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  

        [BsonElement("user_id")]
        public int UserId { get; set; }  

        [BsonElement("user_name")]
        public string UserName { get; set; } 

        [BsonElement("email")]
        public string Email { get; set; }  

        [BsonElement("password")]
        public string Password { get; set; } 

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }  
    }
}
