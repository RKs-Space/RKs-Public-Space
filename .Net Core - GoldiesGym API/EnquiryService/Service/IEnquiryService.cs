using EnquiryService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnquiryService.Service
{
    /*
    * Interface for EnquiryService
    */

    public interface IEnquiryService
    {
        Task<int> CreateAsync(Enquiry enquiry);

        Task<List<Enquiry>> GetAsync();

        Task<Enquiry> GetAsync(int enquiryId);

        Task<bool> UpdateAsync(int enquiryId, Enquiry enquiry);
        Task<int> CreateAsyncF(Enquiry enquiry);
    }
}