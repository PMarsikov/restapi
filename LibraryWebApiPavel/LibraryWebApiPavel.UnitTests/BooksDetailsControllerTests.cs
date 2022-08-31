using LibraryWebApiPavel.Controllers;
using LibraryWebApiPavel.Dto;
using LibraryWebApiPavel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace LibraryWebApiPavel.UnitTests
{
    internal class BooksDetailsControllerTests
    {
        BooksDetailsController controller;
        Mock<IBookService> mockedBookService;

        public BooksDetailsControllerTests()
        {
            mockedBookService = new Mock<IBookService>();
            mockedBookService.Setup(x => x.GetBooksDetails())
                .Returns(new List<BookDetailDto> {
                new BookDetailDto()
                {
                    Id = 1,
                    Title = "Title1",
                    BookYear = 2011,
                    AuthorFirstName = "Afirst Name One",
                    AuthorMiddleName = "Amiddle Name One",
                    AuthorLastName = "Alast Name One",
                    AuthorBirthDay = new DateTime(2015, 12, 31)
                },
                new BookDetailDto()
                {
                    Id = 2,
                    Title = "Title12",
                    BookYear = 2011,
                    AuthorFirstName = "Afirst Name Two",
                    AuthorMiddleName = "Amiddle Name Two",
                    AuthorLastName = "Alast Name Two",
                    AuthorBirthDay = new DateTime(2015, 12, 31)
                }
                });
        }
      
        [SetUp]
        public void Init()
        {
            controller = new BooksDetailsController(mockedBookService.Object);
        }

        [Test]
        public async Task BooksDetailsController_GetObjectsAsync_SuccesfullyRecievedBooksDetails()
        {
            // Act
            var response = await controller.GetObjectsAsync();
            var okResult = response as OkObjectResult;
            var resultResponse = response as ObjectResult;
            var result = resultResponse?.Value;
            var resultList = result as List<BookDetailDto>;
          
            // Assert
            Assert.IsNotNull(okResult);
            Assert.That(resultList?.Count, Is.EqualTo(2));
        }
    }
}
