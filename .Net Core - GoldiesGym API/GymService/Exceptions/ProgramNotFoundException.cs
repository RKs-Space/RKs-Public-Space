using System;

namespace GymService.Exceptions
{
    /*
    * Custom Exception thrown when Program being requested does not exist
    */

    public class ProgramNotFoundException: Exception
    {
        public ProgramNotFoundException()
        {
        }

        public ProgramNotFoundException(string message) : base(message)
        {
        }
    }
}
