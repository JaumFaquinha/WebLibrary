
namespace WebLibrary.Entities.Models
{
    public class ALoan
    {
        public string? User { get; set; }
        public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnedAt { get; set; }
    }
}