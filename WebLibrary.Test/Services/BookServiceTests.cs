using Xunit;
using Moq;
using System.Collections.Generic;
using WebLibrary.Entities.Models;
using WebLibrary.API.Services;
using WebLibrary.API.Repositories;
using WebLibrary.Entities.Repositories;

namespace WebLibrary.Test.Services
{
    public class BookServiceTests
    {
        [Fact]
        public void Search_ReturnsMatchingBooks()
        {
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<ABook>
            {
                new ABook { Id = "1", Title = "Clean Code", Author = "Robert Martin" },
                new ABook { Id = "2", Title = "Domain Driven Design", Author = "Eric Evans" }
            });

            var service = new BookService(mockRepo.Object);
            var result = service.Search("Clean");

            Assert.Single(result);
            Assert.Equal("Clean Code", result[0].Title);
        }

        [Fact]
        public void GetTopBooks_ReturnsBooksOrderedByLoanCount()
        {
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<ABook>
            {
                new ABook { Title = "Book A", Loans = new List<ALoan> { new ALoan(), new ALoan() } },
                new ABook { Title = "Book B", Loans = new List<ALoan> { new ALoan() } }
            });

            var service = new BookService(mockRepo.Object);
            var result = service.GetTopBooks();

            Assert.Equal("Book A", result[0].Title);
        }
    }
}