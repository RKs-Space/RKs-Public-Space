using System;

namespace UserService.Exceptions
{
    /*
     * Custom Exception thrown when User with existing UserId is being added
    */

    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string message) : base(message)
        {
        }
    }

}
