using System;

namespace EnquiryService.Exceptions
{
    /*
     * Custom Exception thrown when Enquiry with existing EnquiryId is being added
    */

    public class EnquiryAlreadyExistsException:Exception
    {
        public EnquiryAlreadyExistsException()
        {
        }

        public EnquiryAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
