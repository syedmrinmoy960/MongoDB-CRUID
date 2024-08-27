using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDB_CRUID.Models
{
    public class eclogs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  

        [BsonElement("request_body")]
        public string RequestBody { get; set; }

        [BsonElement("time")]
        public DateTime Time { get; set; }

        [BsonElement("request_for")]
        public string RequestFor { get; set; } 

        [BsonElement("status_code")]
        public int StatusCode { get; set; } 
    }
}
