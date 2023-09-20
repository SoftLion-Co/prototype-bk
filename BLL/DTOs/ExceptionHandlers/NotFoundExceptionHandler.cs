using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.ExceptionHandlers;

public class NotFoundExceptionHandler : IExceptionHandler<NotFoundException>
{
    public async Task HandleException(HttpContext context, NotFoundException exception)
    {
        context.Response.StatusCode = exception.StatusCode;
        await context.Response.WriteAsJsonAsync(ResponseEntity.CreateWithOneMessage(exception));
    }
}