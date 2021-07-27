using EnquiryService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using EnquiryService.Exceptions;

namespace EnquiryService.Repository
{
    /*
     * This class contains CRUD methods for Enquiry
     * Should implement all methods listed down by IEnquiryRepository
     * Id for Enquiry should be generated while inserting record with seed value 1001
     */

    public class EnquiryRepository : IEnquiryRepository
    {
        readonly EnquiryDbContext context;
        public EnquiryRepository(EnquiryDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task<int> CreateAsync(Enquiry enquiry)
        {
                await context.Enquiries.InsertOneAsync(enquiry);
                var result = await context.Enquiries.Find(r => r.EnquiryId.Equals(enquiry.EnquiryId)).FirstOrDefaultAsync();
                return result.EnquiryId;  
        }

        public Task<List<Enquiry>> GetAsync()
        {
            return context.Enquiries.Find(_ => true).ToListAsync();
        }

        public Task<Enquiry> GetAsync(int enquiryId)
        {
            var result = context.Enquiries.Find(r => r.EnquiryId.Equals(enquiryId)).FirstOrDefaultAsync();
            if (result != null)
            {
                return context.Enquiries.Find(r => r.EnquiryId.Equals(enquiryId)).FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> IsEnquiryExistsAsync(int enquiryId)
        {
            var enquiry =  context.Enquiries.Find(r => r.EnquiryId.Equals(enquiryId)).ToList().Count;
            if (enquiry > 0)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        //public async Task<bool> IsEnquiryExistAsync(int enquiryId)
        //{
        //    return true;
        //}
        public Task<bool> UpdateAsync(int enquiryId, Enquiry enquiry)
        {
            var updateResult = context.Enquiries.ReplaceOne(r => r.EnquiryId == enquiryId, enquiry);
            return Task.FromResult(updateResult.ModifiedCount > 0 ? true : false);
        }
    }
}
