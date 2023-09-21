using BLL.DTOs.Response;

namespace BLL.DTOs.Exceptions
{
    public interface IAppException
    {
        int StatusCode { get; }
        IEnumerable<Error> Errors { get; }
    }
}
