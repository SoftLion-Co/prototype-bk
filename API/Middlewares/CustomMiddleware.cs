namespace API.Middlewares
{
    public static class CustomMiddleware
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ExceptionMiddleware> ();
        }
    }
}
