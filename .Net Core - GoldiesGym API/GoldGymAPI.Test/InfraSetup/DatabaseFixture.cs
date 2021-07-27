using EnquiryService.Models;
using GymService.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using UserService.Models;

namespace GoldGymAPI.Test.InfraSetup
{
    public class DatabaseFixture : IDisposable
    {
        public UserDbContext userContext;
        public ProgramDbContext programContext;
        public EnquiryDbContext enquiryContext;

        public DatabaseFixture()
        {
            Environment.SetEnvironmentVariable("MONGO_CONNECTION_STRING", "mongodb://localhost:27017");

            ConfigureUserContext();
            ConfigureProgramContext();
            ConfigureEnquiryContext();
        }

        public void ConfigureProgramContext()
        {
            Environment.SetEnvironmentVariable("MONGO_DATABASE_NAME",  "gymprogram_testdb");

            programContext = new ProgramDbContext();

            programContext.Programs.DeleteMany(Builders<Program>.Filter.Empty);
            programContext.Programs.InsertMany(new List<Program>
            {
                new Program
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
            });
        }

        public void ConfigureEnquiryContext()
        {
            Environment.SetEnvironmentVariable("MONGO_DATABASE_NAME", "gymenquiry_testdb");

            enquiryContext = new EnquiryDbContext();

            enquiryContext.Enquiries.DeleteMany(Builders<Enquiry>.Filter.Empty);
            enquiryContext.Enquiries.InsertMany(new List<Enquiry>
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
            });
        }

        public void ConfigureUserContext()
        {
            Environment.SetEnvironmentVariable("MONGO_DATABASE_NAME", "gymuser_testdb");

            userContext = new UserDbContext();

            userContext.Users.DeleteMany(Builders<User>.Filter.Empty);
            userContext.Users.InsertMany(new List<User>
            {
                new User
                {
                    UserId = "sr-shankar",
                    Password = "Password@123",
                    Role = "Admin"
                },

                new User
                {
                    UserId = "sr-tina",
                    Password = "Password@123",
                    Role = "Manager"
                }
            });

        }

        public void Dispose()
        {
            userContext = null;
            programContext = null;
            enquiryContext = null;
        }
    }
}
