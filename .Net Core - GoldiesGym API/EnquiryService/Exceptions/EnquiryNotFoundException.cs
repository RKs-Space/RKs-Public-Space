using System;

namespace EnquiryService.Exceptions
{
    /*
    * Custom Exception thrown when Enquiry being requested does not exist
    */

    public class EnquiryNotFoundException: Exception
    {
        public EnquiryNotFoundException()
        {
        }

        public EnquiryNotFoundException(string message) : base(message)
        {
        }
    }
}
