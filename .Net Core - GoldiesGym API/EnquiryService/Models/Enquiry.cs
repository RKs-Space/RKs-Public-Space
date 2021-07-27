using MongoDB.Bson.Serialization.Attributes;

namespace EnquiryService.Models
{
    /*
     * Model class definition for Enquiry entity
     */
    [BsonIgnoreExtraElements]
    public class Enquiry
    {
        [BsonId]
        public int EnquiryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Query { get; set; }
        public string Status { get; set; }
        public string CseRemarks { get; set; }
    }
}