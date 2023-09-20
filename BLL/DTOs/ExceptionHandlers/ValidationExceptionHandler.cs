using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.ExceptionHandlers;

public class ValidationExceptionHandler : IExceptionHandler<ValidationException>
{
    public async Task HandleException(HttpContext context, ValidationException exception)
    {
        context.Response.StatusCode = exception.StatusCode;
        await context.Response.WriteAsJsonAsync(ResponseEntity.CreateWithOneMessage(exception));
    }
}