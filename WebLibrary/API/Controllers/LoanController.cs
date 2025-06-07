using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebLibrary.API.Services;
using WebLibrary.Entities.Models;
using WebLibrary.API.DTOs;
using WebLibrary.Entities.Interfaces;

namespace WebLibrary.API.Controllers
{
    [Route("books/{bookId}/loans")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public IActionResult RegisterLoan(string bookId, [FromBody] LoanDto dto)
        {
            if (dto == null)
            {
                return BadRequest("O empréstimo não pode ser nulo.");
            }

            var loan = new ALoan
            {
                User = dto.User,
                BorrowedAt = dto.BorrowedAt,
                ReturnedAt = dto.ReturnedAt 
            };

            var loanId = _loanService.RegisterLoan(bookId, loan);
            if (string.IsNullOrEmpty(loanId))
            {
                return NotFound("Livro não encontrado ou empréstimo já registrado.");
            }

            return Ok("Loan registered");
        }
    }
}