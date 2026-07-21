using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionMessage = context.Exception.Message;
            File.AppendAllText("exceptions.log", $"{DateTime.Now}: {exceptionMessage}\n");
            
            context.Result = new ObjectResult(new { error = "Internal server error" })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
