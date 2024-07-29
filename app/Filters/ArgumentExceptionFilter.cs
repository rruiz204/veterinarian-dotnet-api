using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Veterinarian_Dotnet_Api.App.Filters;

public class ArgumentExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    if (context.Exception is ArgumentException)
    {
      context.Result = new BadRequestObjectResult(new { message = context.Exception.Message });
      context.ExceptionHandled = true;
    }
  }
}