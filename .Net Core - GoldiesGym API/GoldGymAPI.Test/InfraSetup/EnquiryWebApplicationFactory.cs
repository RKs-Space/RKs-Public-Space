using EnquiryService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace GoldGymAPI.Test.InfraSetup
{
    public class EnquiryWebApplicationFactory<TStartup> : WebApplicationFactory<EnquiryService.Startup>
    {
        EnquiryDbContext enquiryDb = null;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("APPLICATIONNAME", "EnquiryService");

            Environment.SetEnvironmentVariable("MONGO_CONNECTION_STRING", "mongodb://localhost:27017");
            Environment.SetEnvironmentVariable("MONGO_DATABASE_NAME", "gymenquiry_testdb");


            builder.ConfigureServices(s =>
            {
                s.AddScoped<EnquiryDbContext>();

                // Build the service provider.
                var sp = s.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;

                enquiryDb = scopedServices.GetRequiredService<EnquiryDbContext>();

                var logger = scopedServices.GetRequiredService<ILogger<EnquiryWebApplicationFactory<TStartup>>>();

                try
                {
                    // Seed the database with some specific test data.
                    enquiryDb.Enquiries.DeleteMany(Builders<Enquiry>.Filter.Empty);
                    enquiryDb.Enquiries.InsertMany(new List<Enquiry> {
                            new Enquiry
                            {
                                EnquiryId = 1001,
                                Name = "Ravi",
                                Email = "ravi@sro.in",
                                Mobile = "9898987665",
                                Status = "Open",
                                Query = "Any batch on aerobics ?",
                            }
                });
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        "database with test messages. Error: {ex.Message}");
                }
            });
        }
        protected override void Dispose(bool disposing)
        {
            enquiryDb.Enquiries.DeleteMany(Builders<Enquiry>.Filter.Empty);
            enquiryDb = null;
        }

    }
}
