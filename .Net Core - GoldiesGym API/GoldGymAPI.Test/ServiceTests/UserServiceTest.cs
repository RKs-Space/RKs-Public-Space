using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UserService.Exceptions;
using UserService.Models;
using UserService.Repository;
using UserService.Service;

namespace GoldGymAPI.Test.ServiceTests
{
    public class UserServiceTest
    {
        readonly IUserService service;
        readonly Mock<IUserRepository> repository;


        public UserServiceTest()
        {
            repository = new Mock<IUserRepository>();

            service = new UserService.Service.UserService(repository.Object);

        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestCreateSuccess()
        {
            //Arrange
            User user = new User
            {
                UserId = "sr-vikram",
                Password = "Password@123",
                Role = "User"
            };

            repository.Setup(r => r.CreateAsync(user)).Returns(Task.FromResult(user.UserId));

            //Act
            var result = await service.CreateAsync(user);

            //Assert
            Assert.That(result, Is.EqualTo(user.UserId));
        }

        [Test, Order(2)]
        public async Task TestValidateSuccess()
        {
            //Arrange
            User user = new User
            {
                UserId = "sr-vikram",
                Password = "Password@123",
                Role = "User"
            };

            repository.Setup(r => r.LoginUser(user)).Returns(Task.FromResult(user));

            //Act
            var result = await service.ValidateAsync(user);

            //Assert
            Assert.That(result.UserId, Is.EqualTo(user.UserId));

        }

        #endregion

        #region negative_test_cases

        [Test, Order(3)]
        public void TestCreateFailure()
        {
            //Arrange
            User user = new User
            {
                UserId = "sr-vikram",
                Password = "Password@123",
                Role = "User"
            };

            repository.Setup(r => r.IsUserExistsAsync(user.UserId)).Returns(Task.FromResult(true));

            //Assert
            Assert.That(() => service.CreateAsync(user),
                Throws.TypeOf(typeof(UserAlreadyExistsException))
                .And.Message.Contains($"UserId {user.UserId} is taken !!!"));
        }

        [Test, Order(4)]
        public void TestValidateFailure()
        {
            //Arrange
            User user = new User
            {
                UserId = "sr-vikram",
                Password = "Password@1234",
                Role = "User"
            };
            User usr = null;

            repository.Setup(r => r.LoginUser(user)).Returns(Task.FromResult(usr));

            //Assert
            Assert.That(() => service.ValidateAsync(usr),
                Throws.TypeOf(typeof(UserNotFoundException))
                .And.Message.Contains($"Invalid Login Credentials !!!"));
        }

        #endregion

    }
}
