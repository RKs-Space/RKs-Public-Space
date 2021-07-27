using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace UserService.Models
{
    /*
     * Model class definition for User entity
     */
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
