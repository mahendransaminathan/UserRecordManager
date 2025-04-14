using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserProfile.Controllers;
using UserProfile.Entities;
using UserProfile.Services;
using System;

namespace UserProfile.NUnitTests
{
    public class UserControllerTests
    {
        private Mock<IUserService> _mockUserService;
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UserController(_mockUserService.Object);
        }

        private User GetSampleUser(int userId = 1, string firstName = "Sami")
        {
            return new User
            {
                UserId = userId,
                FirstName = firstName,
                LastName = "vkp",
                Email = "sami.vkp@example.com",
                Username = "samivkp",
                Password = "SecurePassword123",
                PhoneNumber = "0987654321",
                DateOfBirth = new DateTime(1985, 1, 1)
            };
        }

        [Test]
        public async Task GetUserById_ReturnsOk_WhenUserExists()
        {
            var user = GetSampleUser(1, "cbe");
            _mockUserService.Setup(s => s.GetUserById(1)).ReturnsAsync(user);

            var result = await _controller.GetUserById(1);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(user));
        }

        [Test]
        public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            _mockUserService.Setup(s => s.GetUserById(99)).ReturnsAsync((User?)null);

            var result = await _controller.GetUserById(99);

            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task GetAllUsers_ReturnsOk_WithListOfUsers()
        {
            var users = new List<User>
            {
                GetSampleUser(1, "Alice"),
                GetSampleUser(2, "Bob")
            };
            _mockUserService.Setup(s => s.GetAllUsers()).ReturnsAsync(users);

            var result = await _controller.GetAllUsers();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(users));
        }

        // [Test]
        // public async Task CreateUser_ReturnsBadRequest_WhenUserIsInvalid()
        // {
        //     // Create an incomplete User object (only set required properties for testing purposes)
        //     var user = new User
        //     {
        //         FirstName = "",  // Simulating an invalid user (missing required value)
        //         LastName = "",    // You can leave other required fields empty or invalid as needed
        //         Email = "",       // Simulate an invalid email
        //         Username = "",    // Simulate an invalid username
        //         Password = "",    // Simulate an invalid password
        //         PhoneNumber = "",  // Simulate an invalid phone number
        //         DateOfBirth = DateTime.MinValue // Simulate an invalid date of birth
        //     };
        //     _controller.ModelState.AddModelError("FirstName", "Required");

            
        //     var result = await _controller.CreateUser(user);

        //     Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        // }

        [Test]
        public async Task UpdateUser_ReturnsOk_WhenUpdatedSuccessfully()
        {
            var user = GetSampleUser(2, "Bob");
            _mockUserService.Setup(s => s.UpdateUser(2, user)).ReturnsAsync(user);

            var result = await _controller.UpdateUser(2, user);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.Value, Is.EqualTo(user));
        }

        [Test]
        public async Task UpdateUser_ReturnsBadRequest_WhenIdMismatch()
        {
            var user = GetSampleUser(1, "Mismatch");

            var result = await _controller.UpdateUser(2, user);

            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
    }
}
