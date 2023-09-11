using System.Net;
using BLL.DTOs.Exceptions;

namespace BLL.DTOs.Response
{
    public class ResponseEntity<TResult> : ResponseEntity
    {
        public ResponseEntity(HttpStatusCode httpStatusCode, TResult result) : base(httpStatusCode)
        {
            Result = result;
        }
        
        public TResult? Result { get; set; }
    }
    
    public class ResponseEntity
    {
        public ResponseEntity(HttpStatusCode httpStatusCode)
        {
            StatusCode = (int)httpStatusCode;
        }
        
        public ResponseEntity(HttpStatusCode httpStatusCode, IEnumerable<Error> errors)
        {
            StatusCode = (int)httpStatusCode;
            Errors = errors;
        }
        
        public ResponseEntity(int statusCode, IEnumerable<Error>? errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
        
        // public ResponseEntity(HttpStatusCode httpStatusCode, string error)
        // {
        //     StatusCode = (int)httpStatusCode;
        //     Errors = new List<Error>(){new Error(error)};
        // }

        public static ResponseEntity CreateWithOneMessage(IAppException exception)
        {
            return new ResponseEntity(exception.StatusCode, exception.Errors);
        }
        
        public int StatusCode { get; set; }
        
        public IEnumerable<Error>? Errors { get; set; }
    }
}
