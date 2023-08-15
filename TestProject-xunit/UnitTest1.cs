using lib.Domain;
using Lib.Application;
using Lib.Application.Contracts;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestProject_xunit
{
    public class UnitTest1
    {

        [Fact]
        public async Task TestBookServiceAsync()
        {

            // Arrange
            var bookRepositoryMock = new Mock<IBookRepository>();
            var book = new bookDto { id = 99, 
                title = "آنچه از شرکت‌های موفق آموخته‌ایم"
            };
            bookRepositoryMock.Setup(repo => repo.GetBookAsync(99)).ReturnsAsync(book);
            var bookService = new BookService(bookRepositoryMock.Object);

            // Act
            bookDto result = await bookService.GetBookAsync(99);

            // Assert
            Assert.Equal<string>(result.title, "آنچه از شرکت‌های موفق آموخته‌ایم");
            Assert.Equal<string>(result.title, book.title);
        }
    }
}
