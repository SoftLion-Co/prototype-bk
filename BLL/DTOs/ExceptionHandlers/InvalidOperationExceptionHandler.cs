using BLL.DTOs.Response;
using Microsoft.AspNetCore.Http;
using InvalidOperationException = BLL.DTOs.Exceptions.InvalidOperationException;

namespace BLL.DTOs.ExceptionHandlers;

public class InvalidOperationExceptionHandler : IExceptionHandler<InvalidOperationException>
{
    public async Task HandleException(HttpContext context, InvalidOperationException exception)
    {
        context.Response.StatusCode = exception.StatusCode;
        await context.Response.WriteAsJsonAsync(ResponseEntity.CreateWithOneMessage(exception));
    }
}