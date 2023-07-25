using BLL.DTOs.Response;

namespace BLL.DTOs.Exceptions
{
    public class NotFoundException : Exception, IAppException
    {
        public NotFoundException(IEnumerable<Error> errors)
        {
            Errors = errors;
        }
        public int StatusCode => 404;

        public IEnumerable<Error> Errors { get; private set; }
        public static NotFoundException Default<TEntity>()
        {
            return new NotFoundException(new List<Error>() { new Error($"{typeof(TEntity)} not found") });
        }
    }
}
