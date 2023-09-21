using System.Net;

namespace BLL.DTOs.Exceptions;

public class InvalidOperationException : BaseException
{
    public override int StatusCode => 500;
    public InvalidOperationException(string error) : base(error)
    {
    }

    public InvalidOperationException(IEnumerable<string> errors) : base(errors)
    {
    }
}