using GymService.Exceptions;
using GymService.Filters;
using GymService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GymService.Controllers
{
    /* This API controller provides endpoints to manage gym Program details
     * All Users should be able to access Programs and it's details
     * Only Users in Role Admin should be Authorized to manage the gym Program Details
     * Should handle exceptions using filter instead of try catch block
     */
    [ExceptionHandler]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        IProgramService _service;
        public ProgramController(IProgramService Service)
        {
            _service = Service;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Models.Program program)
        {
            try
            {
                return Created("", _service.CreateAsync(program).Result);
            }
            catch (ProgramAlreadyExistsException pae)
            {
                return Conflict(pae.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
           return Ok(_service.GetAsync().Result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var validProgram = _service.GetAsync(id).Result;
            if (validProgram != null)
            {
                return Ok(validProgram);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Models.Program program)
        {
            var programbyId = _service.GetAsync(id).Result;
            if (programbyId != null)
            {
                return Ok(_service.UpdateAsync(id,program).Result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }

    }
}