namespace WebLibrary.Entities.Models
{
    public class MongoDbSettings
    {
        public string? ConnectionString { get; set; } = null; 
        public string? DatabaseName { get; set; } = null;
        public string? BooksCollection { get; set; } = null;
    }
}