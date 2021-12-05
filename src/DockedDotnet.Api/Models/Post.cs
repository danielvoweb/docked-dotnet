using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DockedDotnet.Api.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}