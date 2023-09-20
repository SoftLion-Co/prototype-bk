using BLL.DTOs.ExceptionHandlers;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var clasType = typeof(IExceptionHandler<>).MakeGenericType(ex.GetType());
                var handler = httpContext.RequestServices.GetService(clasType);

                if (handler != null)
                {
                    var method = handler.GetType().GetMethod("HandleException") ??
                                 throw new InvalidOperationException("Method HandleException was not found");

                    var task = (Task)method.Invoke(handler, new object[] { httpContext, ex })!;
                    await task;
                }
            }
        }
    }
}
