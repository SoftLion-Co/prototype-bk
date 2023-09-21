using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.ExceptionHandlers;

public interface IExceptionHandler<TException> where TException: BaseException
{
    Task HandleException(HttpContext context, TException exception);
}