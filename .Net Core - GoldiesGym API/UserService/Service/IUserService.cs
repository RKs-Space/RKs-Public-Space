using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Service
{
    /*
     * Interface for UserService
     */

    public interface IUserService
    {
        Task<User> LoginAsync(User user);

        Task<string> CreateAsync(User user);

        Task<User> ValidateAsync(User user);

    }
}