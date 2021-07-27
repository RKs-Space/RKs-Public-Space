using EnquiryService.Exceptions;
using EnquiryService.Models;
using EnquiryService.Repository;
using EnquiryService.Service;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldGymAPI.Test.ServiceTests
{
    public class EnquiryServiceTest
    {
        readonly IEnquiryService service;
        readonly Mock<IEnquiryRepository> repository;


        public EnquiryServiceTest()
        {
            repository = new Mock<IEnquiryRepository>();

            service = new EnquiryService.Service.EnquiryService(repository.Object);
        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestCreateSuccess()
        {
            //Arrange
            Enquiry newEnquiry = new Enquiry()
            {
                EnquiryId = 1003,
                Name = "Sandhya",
                Email = "sandhya@gmail.com",
                Mobile = " 9878767654",
                Query = "Are you also offering personal trainers ?"
            };

            repository.Setup(repo => repo.CreateAsync(newEnquiry))
                .Returns(Task.FromResult(newEnquiry.EnquiryId));

            //Act
            var result = await service.CreateAsync(newEnquiry);

            //Assert
            Assert.That(result, Is.EqualTo(1003));
        }

        [Test, Order(2)]
        public async Task TestGetSuccess()
        {
            //Arrange
            repository.Setup(repo => repo.GetAsync())
                .Returns(Task.FromResult(SeedData()));

            //Act
            var result = await service.GetAsync();

            //Assert
            Assert.That(result, Is.TypeOf(typeof(List<Enquiry>)));
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [TestCase(1001), Order(3)]
        [TestCase(1002)]
        public async Task TestGetByIdSuccess(int enquiryId)
        {
            //Arrange
            repository.Setup(repo => repo.GetAsync(enquiryId))
                .Returns(Task.FromResult(SeedData().Where(e => e.EnquiryId == enquiryId).FirstOrDefault()));

            //Act
            var result = await service.GetAsync(enquiryId);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(Enquiry)));
            Assert.That(result.EnquiryId, Is.EqualTo(enquiryId));
        }

        [Test, Order(4)]
        public async Task TestPutSuccess()
        {
            //Arrange

            int enquiryId = 1001;
            var enquiry = new Enquiry
            {
                EnquiryId = 1003,
                Name = "Harish",
                Email = "harish@gmail.com",
                Mobile = "9988776655",
                Query = "How many sessions for Zoomba program in week ?",
                Status = "Closed",
                CseRemarks = "3 days a week"
            };
            repository.Setup(repo => repo.GetAsync(enquiryId))
                .Returns(Task.FromResult(SeedData().Where(e => e.EnquiryId == enquiryId).FirstOrDefault()));

            repository.Setup(repo => repo.UpdateAsync(enquiryId, enquiry))
                .Returns(Task.FromResult(true));

            //Act
            var result = await service.UpdateAsync(enquiryId, enquiry);

            //Assert
            Assert.That(result, Is.True);
        }

        #endregion

        #region negative_test_cases

        [Test, Order(5)]
        public void TestCreateFailure()
        {
            //Arrange
            var enquiry = new Enquiry
            {
                EnquiryId = 1003,
                Name = "Harish",
                Email = "harish@gmail.com",
                Mobile = "9988776655",
                Query = "How many sessions for Zoomba program in week ?",
                Status = "Closed",
                CseRemarks = "3 days a week"
            };


            repository.Setup(repo => repo.GetAsync(enquiry.EnquiryId))
                .Returns(Task.FromResult(enquiry));

            //Assert
            Assert.That(async () => await service.CreateAsyncF(enquiry),
                Throws.TypeOf(typeof(EnquiryAlreadyExistsException))
                .And.Message.EqualTo($"Enquiry with Id {enquiry.EnquiryId} Already Exists !!!"));
        }

        [TestCase(1005), Order(6)]
        public void TestGetByIdFailure(int enquiryId)
        {
            //Arrange
            Enquiry enquiry = null;
            repository.Setup(repo => repo.GetAsync(enquiryId))
                .Returns(Task.FromResult(enquiry));

            //Assert
            Assert.That(async () => await service.GetAsync(enquiryId),
                Throws.TypeOf(typeof(EnquiryNotFoundException))
                .And.Message.EqualTo($"Enquiry with Id {enquiryId} Does Not Exist !!!"));
        }

        [Test, Order(7)]
        public void TestPutFailure()
        {
            //Arrange

            int enquiryId = 1003;
            Enquiry enquiry = null;

            var updatedEnquiry = new Enquiry
            {
                EnquiryId = 1003,
                Name = "Harish",
                Email = "harish@gmail.com",
                Mobile = "9988776655",
                Query = "How many sessions for Zoomba program in week ?",
                Status = "Closed",
                CseRemarks = "3 days a week"
            };
            repository.Setup(repo => repo.GetAsync(enquiryId))
                .Returns(Task.FromResult(enquiry));

            //Assert
            Assert.That(async () => await service.UpdateAsync(enquiryId, updatedEnquiry),
                Throws.Exception.TypeOf(typeof(EnquiryNotFoundException))
                .And.Message.EqualTo($"Enquiry with Id {enquiryId} Does Not Exist !!!"));
        }

        #endregion

        #region seed_data

        List<Enquiry> SeedData()
        {
            return new List<Enquiry>
            {
                new Enquiry
                {
                    EnquiryId = 1001,
                    Name = "Harish",
                    Email = "harish@gmail.com",
                    Mobile = "9988776655",
                    Query = "How many sessions for Zoomba program in week ?",
                    Status = "Open"
                },
                new Enquiry
                {
                    EnquiryId = 1002,
                    Name = "Ravi",
                    Email = "ravi@gmail.com",
                    Mobile = "7799776655",
                    Query = "Any weekend batch for Yoga in coming month ?",
                    Status = "Open"
                }
            };
        }
        #endregion
    }
}
