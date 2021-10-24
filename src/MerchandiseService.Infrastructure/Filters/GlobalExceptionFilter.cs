﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MerchandiseService.Infrastructure.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var resultObject = new {
                ExceptionType = context.Exception.GetType().FullName,
                ExceptionMessage = context.Exception.Message,
                ExceptionStackTrace = context.Exception.StackTrace
            };

            var jsonResult = new JsonResult(resultObject) {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = jsonResult;
        }
    }
}