using GoldGymAPI.Test.InfraSetup;
using GymService.Models;
using GymService.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldGymAPI.Test.RepositoryTests
{
    public class ProgramRepositoryTest
    {
        readonly IProgramRepository repository;

        public ProgramRepositoryTest()
        {
            DatabaseFixture fixture = new DatabaseFixture();

            repository = new ProgramRepository(fixture.programContext);
        }


        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestCreateSuccess()
        {
            //Arrange
            var program = new Program
            {
                ProgramId = 103,
                ProgramName = "Yoga",
                DurationInMonths = 4,
                Price = 4400,
                DiscountRate = 0,
                IsActive = true,
                CurrentPrice = 4440
            };

            //Act
            var result = await repository.CreateAsync(program);

            //Assert
            Assert.That(result, Is.EqualTo(103));
        }

        [Test, Order(2)]
        public async Task TestGetSuccess()
        {
            //Act
            var result = await repository.GetAsync();

            //Assert
            Assert.That(result, Is.TypeOf(typeof(List<Program>)));
            Assert.That(result.Count, Is.EqualTo(3));

        }

        [TestCase(103), Order(3)]
        [TestCase(102)]
        public async Task TestGetByIdSuccess(int programId)
        {
            //Act
            var result = await repository.GetAsync(programId);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(Program)));
            Assert.That(result.ProgramId, Is.EqualTo(programId));
        }

        [Test, Order(4)]
        public async Task TestPutSuccess()
        {
            //Arrange
            int programId = 103;
            var program = new Program
            {
                ProgramId = 103,
                ProgramName = "Yoga",
                DurationInMonths = 4,
                Price = 5400,
                DiscountRate = 10,
                IsActive = true,
                CurrentPrice = 4860
            };

            //Act
            var result = await repository.UpdateAsync(programId, program);

            //Assert
            Assert.That(result, Is.True);
        }

        #endregion

        #region negative_test_cases

        [TestCase(100), Order(7)]
        public async Task TestGetByIdFailure(int programId)
        {
            //Act
            var result = await repository.GetAsync(programId);

            //Assert
            Assert.That(result, Is.Null);
        }

        [TestCase(100), Order(8)]
        public async Task TestPutFailure(int programId)
        {
            //Arrange
            var program = new Program
            {
                ProgramId = 103,
                ProgramName = "Yoga",
                DurationInMonths = 4,
                Price = 5400,
                DiscountRate = 10,
                IsActive = true,
                CurrentPrice = 4860
            };

            //Act
            var result = await repository.UpdateAsync(programId, program);

            //Assert
            Assert.That(result, Is.False);
        }

        #endregion
    }
}
