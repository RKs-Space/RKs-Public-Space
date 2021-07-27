using GymService.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymService.Filters
{
    /*
    * Custom Filter to handle Exceptions thrown by ProgramService
    */

    public class ExceptionHandlerAttribute: ExceptionFilterAttribute
    {
        public override void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
        {
            var exception = context.Exception.GetType();
            var message = context.Exception.Message;
            if (exception == typeof(ProgramNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exception == typeof(ProgramAlreadyExistsException))
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
