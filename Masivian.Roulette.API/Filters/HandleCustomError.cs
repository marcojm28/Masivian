using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Masivian.Roulette.API.Filters
{
    public class HandleCustomError : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exeption = (Exception)context.Exception;
            var validation = new
            {
                Status = 400,
                Title = "Bad Request",
                Detail = exeption.Message
            };
            var json = new
            {
                errors = new[] { validation}
            };
            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
        }
    }
}
