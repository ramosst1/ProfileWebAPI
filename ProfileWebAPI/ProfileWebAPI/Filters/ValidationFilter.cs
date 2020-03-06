using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProfileWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid) {

                var ErrorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var ErrorMessages = new List<IErrorMessage>(); 

                foreach (var error in ErrorsInModelState) {

                    foreach (var subError in error.Value) {

                        var AErrorMessage = new ErrorMessageDto
                        {
                             FieldName = error.Key , 
                              Message = subError, 
                              StatusCode = "400"

                        };

                        ErrorMessages.Add(AErrorMessage);
                    }

                }
                context.Result = new BadRequestObjectResult(ErrorMessages);

                return; 
            }
            await next();
        }

        
    }
}
