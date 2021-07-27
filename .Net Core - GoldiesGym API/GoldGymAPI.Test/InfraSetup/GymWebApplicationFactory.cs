using GymService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace GoldGymAPI.Test.InfraSetup
{
    public class GymWebApplicationFactory<TStartup> : WebApplicationFactory<GymService.Startup>
    {
        ProgramDbContext programDb = null;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("APPLICATIONNAME", "GymService");

            Environment.SetEnvironmentVariable("MONGO_CONNECTION_STRING", "mongodb://localhost:27017");
            Environment.SetEnvironmentVariable("MONGO_DATABASE_NAME", "gymprogram_testdb");

            builder.ConfigureServices(s =>
            {
                s.AddScoped<ProgramDbContext>();

                // Build the service provider.
                var sp = s.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;

                programDb = scopedServices.GetRequiredService<ProgramDbContext>();

                var logger = scopedServices.GetRequiredService<ILogger<GymWebApplicationFactory<TStartup>>>();

                try
                {
                    // Seed the database with some specific test data.
                    programDb.Programs.DeleteMany(Builders<Program>.Filter.Empty);
                    programDb.Programs.InsertMany(new List<Program> {
                            new GymService.Models.Program
                            {
                                ProgramId=101,
                                ProgramName = "Aerobics",
                                DurationInMonths=10,
                                Price=7600,
                                DiscountRate=0,
                                CurrentPrice=7600,
                                Description="For weight loss"
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
            programDb.Programs.DeleteMany(Builders<Program>.Filter.Empty);
            programDb = null;
        }

    }
}
