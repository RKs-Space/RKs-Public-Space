using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserService.Exceptions;
using UserService.Filters;
using UserService.Models;
using UserService.Service;

namespace UserService.Controllers
{
    /* 
     * This API controller provides endpoints to manage User registration and login requests
     * Should handle exceptions using filter instead of try catch block
     * The signin method should generate JWT Token and return it along with the response
     */
    [ExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService service;
        ITokenGeneratorService _tokenService;

        public UserController(IUserService userService, ITokenGeneratorService tokenService)
        {
            service = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                //service.CreateAsync(user);
                return Created("", service.CreateAsync(user).Result);
            }
            catch (UserAlreadyExistsException uae)
            {
                return Conflict(uae.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            var validUserResult = service.ValidateAsync(user).Result;
            if (validUserResult != null)
            {
                return Ok(_tokenService.GetJWTToken(user.UserId));
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }
    }
}