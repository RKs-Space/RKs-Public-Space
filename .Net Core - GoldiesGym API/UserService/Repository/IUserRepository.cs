using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository
{
    /*
     * Interface for UserRepository
     */

    public interface IUserRepository
    {
        Task<User> LoginUser(User user);
        Task<string> CreateAsync(User User);
        Task<bool> IsUserExistsAsync(string UserId);
        Task<User> ValidateAsync(User user);
    }
}