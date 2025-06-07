using System;

namespace WebLibrary.API.DTOs
{
    public class LoanDto
    {
        public string User { get; set; } = null!;
        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}