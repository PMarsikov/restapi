using LibraryWebApiPavel.Controllers;
using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;

namespace LibraryWebApiPavel.UnitTests
{
    public class BookControllerTests
    {
        readonly DbContextOptions<LibraryContext> options;
        readonly LibraryContext libraryContext;
        BooksController controller;

        public BookControllerTests()
        {
            options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase("Temp")
                .ConfigureWarnings(a => a.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            libraryContext = new LibraryContext(options);
            var mockData = new List<Book>()
            {
                new Book()
                {
                    Id =1,
                    Title ="Title0",
                    AuthorId =1,
                    BookYear = 2001
                },

                new Book()
                {
                    Id =2,
                    Title ="Title1",
                    AuthorId =1,
                    BookYear = 2000
                }
            };

            libraryContext.Books.AddRange(mockData);
            libraryContext.SaveChanges();
        }


        [SetUp]
        public void Init()
        {
            controller = new BooksController(libraryContext);
        }

        [Test]
        public async Task BooksController_GetObjectsAsync_SuccesfullyRecievedBooks()
        {
            // Act
            var response = await controller.GetObjectsAsync();
            var okResult = response as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task BooksController_GetObject_SuccesfullyRecievedBook()
        {
            // Act
            var resultResponse = await controller.Get(1) as ObjectResult;

            // Assert

            var result = resultResponse?.Value as Book;

            Assert.IsNotNull(result);
            Assert.That(result.BookYear, Is.EqualTo(2001));
        }

        [Test]
        public async Task BooksController_GetObject_BookIsNotFound()
        {
            // Act
            var resultResponse = await controller.Get(999) as ObjectResult;

            // Assert

            var result = resultResponse?.Value as Book;

            Assert.Null(result);
        }

        [Test]
        public async Task BooksController_CreateObject_BookCreated()
        {
            // Arrange
            var fakeBook = new Book()
            {
                Id = 8,
                Title = "fakeTitle",
                BookYear = 1992,
                AuthorId = 888
            };

            // Act        
            var response = await controller.Post(fakeBook);
            var bookResult = response.Result as ObjectResult;

            // // Assert
            var result = bookResult?.Value as Book;

            Assert.IsNotNull(result);
            Assert.That(result.Title, Is.EqualTo(fakeBook.Title));
            Assert.That(result.BookYear, Is.EqualTo(fakeBook.BookYear));
        }

        [Test]
        public async Task BooksController_UpdateObject_UpdatedBook()
        {
            // Arrange
            var updateTitle = "updated Title";
            var existingBook = await controller.Get(1) as ObjectResult;
            var book = existingBook?.Value as Book;
            book.Title = updateTitle;

            // Act        
            await controller.Put(book);

            // // Assert
            var updatedBook = await controller.Get(1) as ObjectResult;
            var bookAfterUpdate = updatedBook?.Value as Book;

            Assert.That(bookAfterUpdate, Is.Not.Null);
            Assert.That(bookAfterUpdate.Title, Is.EqualTo(updateTitle));
        }

        [Test]
        public async Task BooksController_DeleteObject_DeletedBook()
        {
            // Act        
            await controller.Delete(2);

            // // Assert
            var updatedBook = await controller.Get(2) as ObjectResult;

            Assert.Null(updatedBook);
        }
    }
}