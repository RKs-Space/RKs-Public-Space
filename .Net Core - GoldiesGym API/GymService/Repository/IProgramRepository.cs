using System.Collections.Generic;
using System.Threading.Tasks;
using GymService.Models;

namespace GymService.Repository
{
    /*
     * Interface for ProgramRepository
     */

    public interface IProgramRepository
    {
        Task<int> CreateAsync(GymService.Models.Program program);

        Task<List<Models.Program>> GetAsync();

        Task<GymService.Models.Program> GetAsync(int programId);

        Task<bool> UpdateAsync(int programId,GymService.Models.Program program);

        Task<bool> IsProgramExistsAsync(string programName);
    }
}