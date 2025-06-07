using Xunit;
using Moq;
using System.Collections.Generic;
using WebLibrary.Entities.Models;
using WebLibrary.API.Services;
using WebLibrary.API.Repositories;
using WebLibrary.Entities.Repositories;

namespace WebLibrary.Test.Services
{
    public class LoanServiceTests
    {
        [Fact]
        public void RegisterLoan_ReturnsSuccess_WhenBookIsAvailable()
        {
            var book = new ABook { Id = "1", Title = "Test Book", Loans = new List<ALoan>() };
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(r => r.GetById("1")).Returns(book);

            var service = new LoanService(mockRepo.Object);
            var result = service.RegisterLoan("1", new ALoan { User = "Alice", BorrowedAt = DateTime.Now });

            Assert.Equal("Loan registered", result);
        }
    }
}