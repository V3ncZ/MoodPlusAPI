using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoodPlus.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
    }
}
