using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymService.Models
{
    /*
     * Model class definition for gym Program entity
     */
    [BsonIgnoreExtraElements]
    public class Program
    {
        [BsonId]
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int DurationInMonths { get; set; }
        public int Price { get; set; }
        public int DiscountRate { get; set; }
        public int CurrentPrice { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
