using GymService.Exceptions;
using GymService.Models;
using GymService.Repository;
using GymService.Service;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldGymAPI.Test.ServiceTests
{
    public class ProgramServiceTest
    {
        readonly IProgramService service;
        readonly Mock<IProgramRepository> repository;


        public ProgramServiceTest()
        {
            repository = new Mock<IProgramRepository>();

            service = new ProgramService(repository.Object);

        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestCreateSuccess()
        {
            //Arrange
            Program newProgram = new Program()
            {
                ProgramId = 1003,
                ProgramName = "Cardio for Flexibility",
                DurationInMonths = 4,
                Price = 5600,
                DiscountRate = 0,
                IsActive = true,
                CurrentPrice = 5600,
                Description = "Batch Starting Soon...."

            };

            repository.Setup(repo => repo.CreateAsync(newProgram))
                .Returns(Task.FromResult(newProgram.ProgramId));

            //Act
            var result = await service.CreateAsync(newProgram);

            //Assert
            Assert.That(result, Is.EqualTo(1003));
        }

        [Test, Order(2)]
        public async Task TestGetSuccess()
        {
            //Arrange
            repository.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(SeedData()));

            //Act
            var result = await service.GetAsync();

            //Assert
            Assert.That(result, Is.TypeOf(typeof(List<Program>)));
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [TestCase(101), Order(3)]
        [TestCase(102)]
        public async Task TestGetByIdSuccess(int programId)
        {
            //Arrange
            repository.Setup(repo => repo.GetAsync(programId))
                .Returns(Task.FromResult(SeedData().Where(e => e.ProgramId == programId).FirstOrDefault()));

            //Act
            var result = await service.GetAsync(programId);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(Program)));
            Assert.That(result.ProgramId, Is.EqualTo(programId));
        }

        [Test, Order(4)]
        public async Task TestPutSuccess()
        {
            //Arrange

            int programId = 101;
            var program = new Program
            {
                ProgramId = 101,
                ProgramName = "Zoomba",
                DurationInMonths = 5,
                Price = 4500,
                DiscountRate = 10,
                IsActive = true,
                CurrentPrice = 4050
            };
            repository.Setup(repo => repo.GetAsync(programId))
                .Returns(Task.FromResult(SeedData().Where(e => e.ProgramId == programId).FirstOrDefault()));

            repository.Setup(repo => repo.UpdateAsync(programId, program))
                .Returns(Task.FromResult(true));

            //Act
            var result = await service.UpdateAsync(programId, program);

            //Assert
            Assert.That(result, Is.True);
        }

        #endregion

        #region negative_test_cases

        [Test, Order(5)]
        public void TestCreateFailure()
        {
            //Arrange
            Program newProgram = new Program()
            {
                ProgramId = 1003,
                ProgramName = "Cardio for Flexibility",
                DurationInMonths = 4,
                Price = 5600,
                DiscountRate = 0,
                IsActive = true,
                CurrentPrice = 5600,
                Description = "Batch Starting Soon...."
            };

            repository.Setup(repo => repo.IsProgramExistsAsync(newProgram.ProgramName))
                .Returns(Task.FromResult(true));

            //Assert
            Assert.That(async () => await service.CreateAsync(newProgram),
                Throws.TypeOf(typeof(ProgramAlreadyExistsException))
                .And.Message.EqualTo($"Program {newProgram.ProgramName} Already Exists !!!"));
        }

        [TestCase(1005), Order(6)]
        public void TestGetByIdFailure(int programId)
        {
            //Arrange
            Program program = null;
            repository.Setup(repo => repo.GetAsync(programId))
                .Returns(Task.FromResult(program));

            //Assert
            Assert.That(async () => await service.GetAsync(programId),
                Throws.TypeOf(typeof(ProgramNotFoundException))
                .And.Message.EqualTo($"Program with Id {programId} Does Not Exist !!!"));
        }

        [Test, Order(7)]
        public void TestPutFailure()
        {
            //Arrange

            int programId = 1003;
            Program program = null;

            var updatedProgram = new Program
            {
                ProgramId = 1003,
                ProgramName = "Cardio for Flexibility",
                DurationInMonths = 4,
                Price = 5600,
                DiscountRate = 0,
                IsActive = true,
                CurrentPrice = 5600,
                Description = "Batch Starting Soon...."

            };
            repository.Setup(repo => repo.GetAsync(programId))
                .Returns(Task.FromResult(program));

            //Assert
            Assert.That(async () => await service.UpdateAsync(programId, updatedProgram),
                Throws.Exception.TypeOf(typeof(ProgramNotFoundException))
                .And.Message.EqualTo($"Program with Id {programId} Does Not Exist !!!"));
        }

        #endregion

        #region seed_data

        List<Program> SeedData()
        {
            return new List<Program>
            {
                new GymService.Models.Program
                {
                    ProgramId = 101,
                    ProgramName = "Zoomba",
                    DurationInMonths = 5,
                    Price = 4500,
                    DiscountRate = 0,
                    IsActive = true,
                    CurrentPrice = 4500
                },
                new Program
                {
                    ProgramId = 102,
                    ProgramName = "Aerobics",
                    DurationInMonths = 8,
                    Price = 8500,
                    DiscountRate = 0,
                    IsActive = true,
                    CurrentPrice = 7650
                }
            };
        }
        #endregion
    }
}
