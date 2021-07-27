using EnquiryService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnquiryService.Repository
{
    /*
     * Interface for EnquiryRepository
     */

    public interface IEnquiryRepository
    {
        Task<int> CreateAsync(Enquiry enquiry);

        Task<List<Enquiry>> GetAsync();
       // Task<bool> IsEnquiryExistAsync(int enquiryId);

        Task<Enquiry> GetAsync(int enquiryId);

        Task<bool> UpdateAsync(int enquiryId, Enquiry enquiry);

        Task<bool> IsEnquiryExistsAsync(int enquiryId);
    }
}