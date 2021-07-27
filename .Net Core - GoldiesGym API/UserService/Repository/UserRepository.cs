using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using MongoDB.Driver.Core.Connections;
using MongoDB.Driver.Core.Servers;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository
{
    /*
     * This class contains CRUD methods for User
     * Should implement all methods listed down by IUserRepository
     */

    public class UserRepository : IUserRepository
    {

        readonly UserDbContext context;
        public UserRepository(UserDbContext dbContext)
        {
            context = dbContext;
        }

        public Task<User> LoginUser(User user)
        {
            //return ValidateAsync(user.UserId, user.Password);
            return ValidateAsync(user);
        }

        public async Task<string> CreateAsync(User user)
        {
            try
            {
                context.Users.InsertOneAsync(user).Wait();
                var result = await context.Users.Find(r => r.UserId.Equals(user.UserId)).FirstOrDefaultAsync();
                return result.UserId;
            }
            catch (AggregateException adx)
            {
                throw adx.InnerException;
            }
        }

        public Task<bool> IsUserExistsAsync(string User)
        {
            var user = context.Users.Find(r => r.UserId.Equals(User)).FirstOrDefault();
            if (user != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public async Task<User> ValidateAsync(User user)
        {
            var result = await context.Users.Find(r => r.UserId.Equals(user.UserId) && r.Password.Equals(user.Password)).FirstOrDefaultAsync();
            return result;
        }
    }
}
