using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WebLibrary.Entities.Models;
using WebLibrary.Entities.Repositories;

namespace WebLibrary.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<ABook> _books;

        public BookRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _books = database.GetCollection<ABook>(settings.Value.BooksCollection);
        }

        public virtual List<ABook> GetAll()
        {
            return _books.Find(book => true).ToList();
        }

        public virtual ABook GetById(string id)
        {
            return _books.Find(book => book.Id == id).FirstOrDefault() ?? throw new KeyNotFoundException("Book not found");
        }

        public virtual ABook Create(ABook book)
        {
            _books.InsertOne(book);
            return book;
        }

        public virtual ABook Update(string id, ABook book)
        {
            _books.ReplaceOne(b => b.Id == id, book);
            return book;
        }

        public virtual string Delete(string id)
        {
            _books.DeleteOne(b => b.Id == id);
            return id;
        }

        public virtual List<ABook> Search(string query)
        {
            var filter = Builders<ABook>.Filter.Or(
                Builders<ABook>.Filter.Regex("Title", new MongoDB.Bson.BsonRegularExpression(query, "i")),
                Builders<ABook>.Filter.Regex("Author", new MongoDB.Bson.BsonRegularExpression(query, "i")),
                Builders<ABook>.Filter.Regex("Genre", new MongoDB.Bson.BsonRegularExpression(query, "i"))
            );
            return _books.Find(filter).ToList();
        }

        public virtual List<ABook> GetTopBooks()
        {
             return _books.Find(book => true)
                    .SortByDescending(book => book.Loans != null && book.Loans.Count > 0)
                    .ToList();
        }
    }
}
