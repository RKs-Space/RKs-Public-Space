using GymService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GymService.Repository
{
    /*
     * This class contains CRUD methods for gym Program
     * Should implement all methods listed down by IProgramRepository
     * Id for Program should be generated while inserting record with seed value 101
     * CurrentPrice should be calculated based upon Price and DiscountRate prior to adding/updating Program record
     */

    public class ProgramRepository: IProgramRepository
    {
        readonly ProgramDbContext context;
        public ProgramRepository(ProgramDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<int> CreateAsync(Models.Program program)
        {
                await context.Programs.InsertOneAsync(program);
                var result = await context.Programs.Find(r => r.ProgramId.Equals(program.ProgramId)).FirstOrDefaultAsync();
                return result.ProgramId;
        }

        public Task<List<Models.Program>> GetAsync()
        {
            return context.Programs.Find(_ => true).ToListAsync();
        }

        public Task<Models.Program> GetAsync(int programId)
        {
            var result =  context.Programs.Find(r => r.ProgramId.Equals(programId)).FirstOrDefaultAsync();
            if (result!=null)
            {
                return  context.Programs.Find(r => r.ProgramId.Equals(programId)).FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        public Task<bool> IsProgramExistsAsync(string programName)
        {
            var program = context.Programs.Find(r => r.ProgramName.Equals(programName)).FirstOrDefault();
            if (program != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateAsync(int programId, Models.Program program)
        {
            var updateResult= context.Programs.ReplaceOne( r => r.ProgramId == programId, program);
            return Task.FromResult(updateResult.ModifiedCount>0 ? true : false);
        }
    }
}
