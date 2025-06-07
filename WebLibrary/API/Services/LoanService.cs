using MongoDB.Bson;
using WebLibrary.API.Repositories;
using WebLibrary.Entities.Interfaces;
using WebLibrary.Entities.Models;
using WebLibrary.Entities.Repositories;

namespace WebLibrary.API.Services
{
    public class LoanService : ILoanService
    {
        private readonly IBookRepository _repository;

        public LoanService(IBookRepository repository)
        {
            _repository = repository;
        }
        
        public virtual string RegisterLoan(string bookId, ALoan loan)
        {
            var book = _repository.GetById(bookId);
            if (book == null)
            {
                throw new KeyNotFoundException("Livro não encontrado");
            }

            if (book.Loans.Any(l => l.ReturnedAt == null))
                return "Livro já está emprestado";

            book.Loans.Add(loan);
            _repository.Update(bookId, book);
            return "Empréstimo registrado com sucesso";
        }
    }
}