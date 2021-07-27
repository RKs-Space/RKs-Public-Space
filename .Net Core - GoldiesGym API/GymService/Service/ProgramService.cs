using GymService.Exceptions;
using GymService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymService.Service
{
    /*
     * This class should implement methods listed by IProgramService
     * The methods of this class should validate the inputs prior to forwarding the call to respective Program repository methods
     * For invalid inputs, methods should throw custom exceptions with simple message
     */

    public class ProgramService:IProgramService
    {
        readonly IProgramRepository repository;
        public ProgramService(IProgramRepository programRepository)
        {
            repository = programRepository;
        }

        public Task<int> CreateAsync(Models.Program program)
        {
            if (repository.IsProgramExistsAsync(program.ProgramName).Result)
            {
                throw new ProgramAlreadyExistsException($"Program {program.ProgramName} Already Exists !!!");
            }
            else
            {
                return repository.CreateAsync(program);
            }
        }

        public Task<List<Models.Program>> GetAsync()
        {
            return repository.GetAsync();
        }

        public Task<Models.Program> GetAsync(int programId)
        {
            if (repository.GetAsync(programId).Result != null )
            {
                return repository.GetAsync(programId);
            }
            else
            {
                throw new ProgramNotFoundException($"Program with Id {programId} Does Not Exist !!!");
            }
        }

        public Task<bool> UpdateAsync(int programId, Models.Program program)
        {
            if (repository.GetAsync(programId).Result != null)
            {
                return repository.UpdateAsync(programId, program);
            }
            else
            {
                throw new ProgramNotFoundException($"Program with Id {programId} Does Not Exist !!!");
            }
        }
    }
}
