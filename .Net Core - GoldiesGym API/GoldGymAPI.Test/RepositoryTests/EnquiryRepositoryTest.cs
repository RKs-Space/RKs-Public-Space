using EnquiryService.Models;
using EnquiryService.Repository;
using GoldGymAPI.Test.InfraSetup;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldGymAPI.Test.RepositoryTests
{
    public class EnquiryRepositoryTest
    {
        readonly IEnquiryRepository repository;
        public EnquiryRepositoryTest()
        {
            DatabaseFixture fixture = new DatabaseFixture();

            repository = new EnquiryRepository(fixture.enquiryContext);
        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestCreateSuccess()
        {
            //Arrange
            var enquiry = new Enquiry
            {
                EnquiryId = 1003,
                Name = "Sandhya",
                Email = "sandhya@gmail.com",
                Mobile = " 9878767654",
                Query = "Are you also offering personal trainers ?"
            };

            //Act
            var result = await repository.CreateAsync(enquiry);

            //Assert
            Assert.That(result, Is.EqualTo(1003));
        }

        [Test, Order(2)]
        public async Task TestGetSuccess()
        {
            //Act
            var result = await repository.GetAsync();

            //Assert
            Assert.That(result, Is.TypeOf(typeof(List<Enquiry>)));
            Assert.That(result.Count, Is.EqualTo(3));
        }

        [TestCase(1003), Order(3)]
        [TestCase(1002)]
        public async Task TestGetByIdSuccess(int enquiryId)
        {
            //Act
            var result = await repository.GetAsync(enquiryId);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(Enquiry)));
            Assert.That(result.EnquiryId, Is.EqualTo(enquiryId));
        }

        [Test, Order(4)]
        public async Task TestPutSuccess()
        {
            //Arrange
            int enquiryId = 1003;
            var enquiry = new Enquiry
            {
                EnquiryId = 1003,
                Name = "Sandhya",
                Email = "sandhya@gmail.com",
                Mobile = " 9878767654",
                Query = "Are you also offering personal trainers ?",
                Status = "Closed",
                CseRemarks = "Yes"
            };

            //Act
            var result = await repository.UpdateAsync(enquiryId, enquiry);

            //Assert
            Assert.That(result, Is.True);
        }

        #endregion

        #region negative_test_cases

        [TestCase(1004), Order(6)]
        public async Task TestGetByIdFailure(int enquiryId)
        {
            //Act
            var result = await repository.GetAsync(enquiryId);

            //Assert
            Assert.That(result, Is.Null);
        }

        [TestCase(1003), Order(8)]
        public async Task TestPutFailure(int enquiryId)
        {
            //Arrange
            var enquiry = new Enquiry
            {
                EnquiryId = 1003,
                Name = "Sandhya",
                Email = "sandhya@gmail.com",
                Mobile = " 9878767654",
                Query = "Are you also offering personal trainers ?",
                Status = "Closed",
                CseRemarks = "Yes"
            };

            //Act
            var result = await repository.UpdateAsync(enquiryId, enquiry);

            //Assert
            Assert.That(result, Is.False);
        }

        #endregion

    }
}
