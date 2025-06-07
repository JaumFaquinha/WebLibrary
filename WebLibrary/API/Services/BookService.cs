
using MongoDB.Bson;
using WebLibrary.API.Repositories;
using WebLibrary.Entities.Interfaces;
using WebLibrary.Entities.Models;
using WebLibrary.Entities.Repositories;

namespace WebLibrary.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<ABook> GetAll()
        {
            return _bookRepository.GetAll().Cast<ABook>().ToList();
        }

        public ABook GetById(string id)
        {
            return _bookRepository.GetById(id);
        }

        public ABook Create(ABook book)
        {
            return _bookRepository.Create(book);
        }

        public ABook Update(string id, ABook book)
        {
            return _bookRepository.Update(id, book);
        }

        public string Delete(string id)
        {
            return _bookRepository.Delete(id);
        }

        public List<ABook> Search(string query)
        {
            return _bookRepository.Search(query).Cast<ABook>().ToList();
        }

        public List<ABook> GetTopBooks()
        {
            return _bookRepository.GetTopBooks().ToList();
        }
    }
}