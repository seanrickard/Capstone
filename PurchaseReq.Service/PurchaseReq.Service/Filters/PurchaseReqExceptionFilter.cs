﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace PurchaseReq.Service.Filters
{
    public class PurchaseReqExceptionFilter : IExceptionFilter
    {
        private readonly bool _isDevelopment;

        public PurchaseReqExceptionFilter(bool isDevelopment)
        {
            _isDevelopment = isDevelopment;
        }


        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            string stackTrace = (_isDevelopment) ? context.Exception.StackTrace : string.Empty;
            string message = ex.Message;
            string error = string.Empty;
            IActionResult actionResult;

            if (ex is DbUpdateConcurrencyException)
            {
                error = "Concurrency Issue.";
                actionResult = new BadRequestObjectResult(new {Error = error, Message = message, StackTrace = stackTrace});
            }
            else
            {
                error = "General Error";
                actionResult = new ObjectResult(new { Error = error, Message = message, StackTrace = stackTrace })
                {
                    StatusCode = 500
                };
            }

            context.Result = actionResult;
        }
    }
}
