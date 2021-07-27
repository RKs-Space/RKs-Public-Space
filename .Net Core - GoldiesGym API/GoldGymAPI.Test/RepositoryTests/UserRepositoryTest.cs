using GoldGymAPI.Test.InfraSetup;
using MongoDB.Driver;
using NUnit.Framework;
using System.Threading.Tasks;
using UserService.Models;
using UserService.Repository;

namespace GoldGymAPI.Test.RepositoryTests
{
    public class UserRepositoryTest
    {
        private readonly IUserRepository repository;

        public UserRepositoryTest()
        {
            DatabaseFixture fixture = new DatabaseFixture();

            repository = new UserRepository(fixture.userContext);
        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestRegisterSuccess()
        {
            //Arrange
            User newUser = new User
            {
                UserId = "sr-bhakti",
                Password = "Password@123",
                Role = "User"
            };

            //Act
            var result = await repository.CreateAsync(newUser);

            //Assert
            Assert.That(result, Is.EqualTo("sr-bhakti"));

        }

        [TestCase("sr-bhakti"), Order(2)]
        [TestCase("sr-tina")]
        public async Task TestUserExistsSuccess(string userId)
        {
            //Act
            var result = await repository.IsUserExistsAsync(userId);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test, Order(3)]
        public async Task TestLoginSuccess()
        {
            //Arrange
            User user = new User
            {
                UserId = "sr-bhakti",
                Password = "Password@123"
            };

            //Act
            var result = await repository.LoginUser(user);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(User)));
            Assert.That(result.Role, Is.EqualTo("User"));
        }


        #endregion

        #region negative_test_cases

        [Test, Order(4)]
        public void TestRegisterFailure()
        {
            //Arrange
            User newUser = new User
            {
                UserId = "sr-bhakti",
                Password = "Password@123",
                Role = "User"
            };

            //Assert
            Assert.That(async () => await repository.CreateAsync(newUser), Throws.Exception.TypeOf(typeof(MongoWriteException)));

        }

        [TestCase("sr-bhakthi"), Order(5)]
        public async Task TestUserExistsFailure(string userId)
        {
            //Act
            var result = await repository.IsUserExistsAsync(userId);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test, Order(6)]
        public async Task TestLoginFailure()
        {
            //Arrange
            User user = new User
            {
                UserId = "sr-bhakti",
                Password = "Password#123"
            };

            //Act
            var result = await repository.LoginUser(user);

            //Assert
            Assert.That(result, Is.Null);
        }

        #endregion
    }
}
