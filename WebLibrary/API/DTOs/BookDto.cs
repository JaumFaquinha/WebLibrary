using System;
using System.Collections.Generic;

namespace WebLibrary.API.DTOs
{
    public class BookDto
    {
        public string? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public List<LoanDto>? Loans { get; set; }
    }
}