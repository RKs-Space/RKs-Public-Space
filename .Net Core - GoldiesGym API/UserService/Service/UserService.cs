

using System.Threading.Tasks;
using UserService.Exceptions;
using UserService.Models;
using UserService.Repository;

namespace UserService.Service
{
    /*
     * This class should implement methods listed by IUserService
     * The methods of this class should validate the inputs prior to forwarding the call to respective User repository methods
     * For invalid inputs, methods should throw custom exceptions with simple message
     */

    public class UserService : IUserService
    {
        readonly IUserRepository repository;
        public UserService(IUserRepository userRepository)
        {
            repository = userRepository;
        }
        public Task<User> LoginAsync(User user)
        {

            return repository.LoginUser(user);

        }

        public Task<string> CreateAsync(User user)
        {
            if (repository.IsUserExistsAsync(user.UserId).Result)
            {
                throw new UserAlreadyExistsException($"UserId {user.UserId} is taken !!!");
            }
            else
            {
                return repository.CreateAsync(user);
            }
        }

        public Task<User> ValidateAsync(User user)
        {
            if (user != null)
            {
                return repository.LoginUser(user);
            }
            else
            {
                throw new UserNotFoundException($"Invalid Login Credentials !!!");
            }
        }
    }
}
