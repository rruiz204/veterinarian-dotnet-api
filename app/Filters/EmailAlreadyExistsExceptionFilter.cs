using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Veterinarian_Dotnet_Api.App.Exceptions;

namespace Veterinarian_Dotnet_Api.App.Filters;

public class EmailAlreadyExistsExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    if (context.Exception is EmailAlreadyExistsException)
    {
      context.Result = new BadRequestObjectResult(context.Exception.Message);
      context.ExceptionHandled = true;
    }
  }
}