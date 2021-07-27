using System;

namespace UserService.Exceptions
{
    /*
   * Custom Exception thrown when User being requested does not exist
   */

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
