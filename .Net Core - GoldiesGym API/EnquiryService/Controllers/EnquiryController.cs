using EnquiryService.Exceptions;
using EnquiryService.Filters;
using EnquiryService.Models;
using EnquiryService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace EnquiryService.Controllers
{
    /* This API controller provides endpoints to manage Enquiries raised / responded
     * Users in role User should be authorized to create Enquiry and view it's details
     * Users in role Manager should be authorized to respond to Enquiries
     * Should handle exceptions using filter instead of try catch block
     */
    [ExceptionHandler]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        IEnquiryService _enquiryService;
        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Program = _enquiryService.GetAsync().Result;

            return Ok(Program);
        }
        [HttpPost]
        public IActionResult Post([FromBody]Enquiry enquiry)
        {
            try
            {
                return Created("", _enquiryService.CreateAsync(enquiry).Result);
            }
            catch (EnquiryAlreadyExistsException pae)
            {
                return Forbid();
            }
        }
        

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var resProgram = _enquiryService.GetAsync(id).Result;
                return Ok(resProgram);
            }
            catch(Exception oEx)
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }            
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Enquiry enquiry)
        {

            var resProgram = _enquiryService.GetAsync(id).Result;
            if (resProgram != null)
            {
                return Ok(_enquiryService.UpdateAsync(id, enquiry).Result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}