using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymService.Service
{
    /*
    * Interface for ProgramService
    */

    public interface IProgramService
    {
        Task<int> CreateAsync(GymService.Models.Program program);

        Task<List<GymService.Models.Program>> GetAsync();

        Task<GymService.Models.Program> GetAsync(int programId);

        Task<bool> UpdateAsync(int programId, GymService.Models.Program program);

    }
}