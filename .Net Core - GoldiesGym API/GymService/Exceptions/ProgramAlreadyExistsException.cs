using System;

namespace GymService.Exceptions
{
    /*
     * Custom Exception thrown when Program with existing ProgramName is being added
    */

    public class ProgramAlreadyExistsException:Exception
    {
        public ProgramAlreadyExistsException()
        {
        }

        public ProgramAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
