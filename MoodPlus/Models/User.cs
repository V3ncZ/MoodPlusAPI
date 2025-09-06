using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoodPlus.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        public string Name { get; set; }
        [BsonRequired]
        public string Email { get; set; }
    }
}
