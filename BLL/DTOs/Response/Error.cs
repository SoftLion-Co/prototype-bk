namespace BLL.DTOs.Response
{
    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
}
