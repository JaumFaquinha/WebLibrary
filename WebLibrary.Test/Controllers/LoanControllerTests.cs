using Moq;
using Xunit;
using WebLibrary.API.Controllers;
using WebLibrary.API.DTOs;
using WebLibrary.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Entities.Interfaces;

namespace WebLibrary.Test.Controllers
{
    public class LoanControllerTests
    {
        [Fact]
        public void LoanBook_ReturnsSuccess()
        {
            var service = new Mock<ILoanService>();
            service.Setup(s => s.RegisterLoan("1", It.IsAny<ALoan>())).Returns("Loan registered");

            var controller = new LoanController(service.Object);
            var result = controller.RegisterLoan("1", new LoanDto
            {
                User = "Tester",
                BorrowedAt = DateTime.Now
            });

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Loan registered", okResult.Value);
        }
    }
}