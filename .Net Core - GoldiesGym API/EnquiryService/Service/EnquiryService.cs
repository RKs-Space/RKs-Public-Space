using EnquiryService.Models;
using EnquiryService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnquiryService.Exceptions;

namespace EnquiryService.Service
{
    /*
     * This class should implement methods listed by IEnquiryService
     * The methods of this class should validate the inputs prior to forwarding the call to respective Enquiry repository methods
     * For invalid inputs, methods should throw custom exceptions with simple message
     */

    public class EnquiryService : IEnquiryService
    {
        readonly IEnquiryRepository repository;
        public EnquiryService(IEnquiryRepository enquiryRepository)
        {
            repository = enquiryRepository;
        }
        public Task<int> CreateAsync(Enquiry enquiry)
        {
            if (repository.IsEnquiryExistsAsync(enquiry.EnquiryId).Result)
            {
                throw new EnquiryAlreadyExistsException($"Enquiry with Id {enquiry.EnquiryId} Already Exists !!!");
            }
            else
            {
                return repository.CreateAsync(enquiry);
            }
        }

        public Task<List<Enquiry>> GetAsync()
        {
            return repository.GetAsync();
        }

        public Task<Enquiry> GetAsync(int enquiryId)
        {
            if (repository.GetAsync(enquiryId).Result != null)
            {
                return repository.GetAsync(enquiryId);
            }
            else
            {
                throw new EnquiryNotFoundException($"Enquiry with Id {enquiryId} Does Not Exist !!!");
            }
        }

        public Task<bool> UpdateAsync(int enquiryId, Enquiry enquiry)
        {
            if (repository.GetAsync(enquiryId).Result != null)
            {
                return repository.UpdateAsync(enquiryId, enquiry);
            }
            else
            {
                throw new EnquiryNotFoundException($"Enquiry with Id {enquiryId} Does Not Exist !!!");
            }
        }

        public Task<int> CreateAsyncF(Enquiry enquiry)
        {
            throw new EnquiryAlreadyExistsException($"Enquiry with Id {enquiry.EnquiryId} Already Exists !!!");
        }
    }
}
