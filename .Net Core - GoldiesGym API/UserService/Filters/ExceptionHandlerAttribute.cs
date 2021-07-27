using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
//using System.Web.Http.ExceptionHandling;
using UserService.Exceptions;

namespace UserService.Filters
{
    /*
    * Custom Filter to handle Exceptions thrown by UserService
    */

    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
        {
            var exception = context.Exception.GetType();
            var message = context.Exception.Message;
            if (exception == typeof(UserNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exception == typeof(UserAlreadyExistsException))
            {
                context.Result = new ConflictObjectResult(message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
        }

    }
}
