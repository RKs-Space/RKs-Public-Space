using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using UserService.Models;

namespace GoldGymAPI.Test.InfraSetup
{
    public class UserWebApplicationFactory<TStartup> : WebApplicationFactory<UserService.Startup>
    {
        UserDbContext userDb = null;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("APPLICATIONNAME", "UserService");

            Environment.SetEnvironmentVariable("MONGO_CONNECTION_STRING", "mongodb://localhost:27017");
            Environment.SetEnvironmentVariable("MONGO_DATABASE_NAME", "gymuser_testdb");

            builder.ConfigureServices(s =>
            {
                s.AddScoped<UserDbContext>();

                // Build the service provider.
                var sp = s.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;

                userDb = scopedServices.GetRequiredService<UserDbContext>();

                var logger = scopedServices.GetRequiredService<ILogger<UserWebApplicationFactory<TStartup>>>();

                try
                {
                    // Seed the database with some specific test data.
                    userDb.Users.DeleteMany(Builders<User>.Filter.Empty);
                    userDb.Users.InsertMany(new List<User> {
                            new User
                            {
                                UserId = "sr-anthony",
                                Password = "Anthony@123",
                                Role = "Admin"
                            },
                            new User
                            {
                                UserId = "sr-bharathi",
                                Password = "Bharathi@123",
                                Role = "Manager"
                            },
                            new User
                            {
                                UserId = "sr-sagar",
                                Password = "Sagar@123",
                                Role = "User"
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
            userDb.Users.DeleteMany(Builders<User>.Filter.Empty);
            userDb = null;
        }

    }
}
