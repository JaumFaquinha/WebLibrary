using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.API.Controllers;
using WebLibrary.Entities.Models;
using WebLibrary.API.Services;
using WebLibrary.Entities.Interfaces;
using WebLibrary.API.DTOs;

namespace WebLibrary.Test.Controllers
{
    public class BookControllerTests
    {
        [Fact]
        public void Get_ReturnsBook_WhenFound()
        {
            var service = new Mock<IBookService>();
            service.Setup(s => s.GetById("1")).Returns(new ABook { Id = "1", Title = "Test", Author = "Author" });

            var controller = new BookController(service.Object);
            var result = controller.GetById("1") as OkObjectResult;

            Assert.NotNull(result);
            var book = result.Value as BookDto;
            Assert.Equal("Test", book?.Title);
        }
    }
}