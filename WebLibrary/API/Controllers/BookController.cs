using Microsoft.AspNetCore.Mvc;
using WebLibrary.API.DTOs;
using WebLibrary.API.Services;
using WebLibrary.Entities.Interfaces;
using WebLibrary.Entities.Models;

namespace WebLibrary.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var book = _bookService.GetById(id);
            if (book == null) return NotFound();

            var dto = new BookDto
            {
                Id = book.Id,
                Title = book.Title ?? string.Empty,
                Author = book.Author ?? string.Empty,
                Loans = book.Loans?.Select(l => new LoanDto
                {
                    User = l.User ?? string.Empty,
                    BorrowedAt = l.BorrowedAt,
                    ReturnedAt = l.ReturnedAt
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDto dto)
        {
            if (dto == null) return BadRequest("O livro não pode ser nulo.");

            var book = new ABook
            {
                Title = dto.Title,
                Author = dto.Author
            };

            var createdBook = _bookService.Create(book);
            dto.Id = createdBook.Id;
            return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] BookDto dto)
        {
            if (dto == null) return BadRequest("O livro não pode ser nulo.");

            var updatedBook = _bookService.Update(id, new ABook
            {
                Title = dto.Title,
                Author = dto.Author,
            });

            if (updatedBook == null) return NotFound();

            dto.Id = updatedBook.Id;
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        { 
            var result = _bookService.Delete(id);
            if (result == null) return NotFound();
            return Ok(new { message = "Livro deletado com sucesso", id = result });
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return BadRequest("A consulta não pode ser vazia.");

            var books = _bookService.Search(query).Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title ?? string.Empty,
                Author = book.Author ?? string.Empty,
                Loans = book.Loans?.Select(l => new LoanDto
                {
                    User = l.User ?? string.Empty,
                    BorrowedAt = l.BorrowedAt,
                    ReturnedAt = l.ReturnedAt
                }).ToList()
            });

            return Ok(books);
        }

        [HttpGet("top")]
        public IActionResult GetTopBooks()
        {
            var topBooks = _bookService.GetTopBooks();
            if (topBooks == null || !topBooks.Any()) return NotFound("Nenhum livro encontrado.");

            var result = topBooks.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title ?? string.Empty,
                Author = book.Author ?? string.Empty,
                Loans = book.Loans?.Select(l => new LoanDto
                {
                    User = l.User ?? string.Empty,
                    BorrowedAt = l.BorrowedAt,
                    ReturnedAt = l.ReturnedAt
                }).ToList()
            });

            return Ok(result);
        }
    }
}