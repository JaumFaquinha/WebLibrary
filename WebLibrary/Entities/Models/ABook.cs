using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebLibrary.Entities.Models
{
    public class ABook
    {
        [BsonId]        
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int? Year { get; set; }
        public List<ALoan> Loans { get; set; } = new List<ALoan>();
    }
}