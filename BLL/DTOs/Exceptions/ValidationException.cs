using BLL.DTOs.Response;

namespace BLL.DTOs.Exceptions;

public class ValidationException : BaseException
{
    public override int StatusCode => 400;
    public ValidationException(string error) : base(error)
    {
    }
    
    public ValidationException(IEnumerable<string> error) : base(error)
    {
    }
}