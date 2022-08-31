using System.Net;
using LibraryWebApiPavel.Controllers;
using LibraryWebApiPavel.Dtos;
using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace LibraryWebApiPavel.UnitTests
{
    internal class UserControllerTests
    {
        AuthController controller;
        Mock<IUserRepository<User>> _userRepository;

        [SetUp]
        public void Init()
        {
            _userRepository = new Mock<IUserRepository<User>>();

            controller = new AuthController(_userRepository.Object);
        }

        [Test]
        public async Task UserController_Register_SuccesfullyRegistered()
        {
            // Arrange
            var response = new ServiceResponse<int>
            {
                Success = true
            };
            _userRepository
                .Setup(p => p.Register(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(response);

            // Act
            var result = await controller.Register(new UserDto());

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)result.Result).StatusCode);
        }

        [Test]
        public async Task UserController_Register_NotSuccesfullyRegistered()
        {
            // Arrange
            var response = new ServiceResponse<int>
            {
                Success = false
            };
            _userRepository
                .Setup(p => p.Register(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(response);

            // Act
            var result = await controller.Register(new UserDto() { Username = "user" });

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, ((ObjectResult)result.Result).StatusCode);
        }

        [Test]
        public async Task UserController_Login_SuccesfullyLogged()
        {
            // Arrange
            var response = new ServiceResponse<string>
            {
                Success = true
            };
            _userRepository
                .Setup(p => p.Login(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(response);

            // Act
            var result = await controller.Login(new UserDto() { Username = "user" });

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)result.Result).StatusCode);
        }

        [Test]
        public async Task UserController_Login_NotSuccesfullyLogged()
        {
            // Arrange
            var response = new ServiceResponse<string>
            {
                Success = false
            };
            _userRepository
                .Setup(p => p.Login(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(response);

            // Act
            var result = await controller.Login(new UserDto() { Username = "user" });

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, ((ObjectResult)result.Result).StatusCode);
        }
    }
}
