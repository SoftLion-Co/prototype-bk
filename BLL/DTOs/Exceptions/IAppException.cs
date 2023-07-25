using BLL.DTOs.Response;

namespace BLL.DTOs.Exceptions
{
    internal interface IAppException
    {
        int StatusCode { get; }
        IEnumerable<Error> Errors { get; }
    }
}
