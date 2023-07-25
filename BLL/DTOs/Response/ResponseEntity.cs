using System.Net;

namespace BLL.DTOs.Response.ResponseEntity
{
    public class ResponseEntity<TResult> : ResponseEntity
    {
        public ResponseEntity(HttpStatusCode httpStatusCode, IEnumerable<Error> errors, TResult result) : base(httpStatusCode, errors) 
        { 
            Result = result;
        }
        public TResult? Result { get; set; }
    }
    public class ResponseEntity
    {
        public ResponseEntity()
        {
            
        }

        public ResponseEntity(HttpStatusCode httpStatusCode, IEnumerable<Error> errors)
        {
            StatusCode = (int)httpStatusCode;
            Errors = errors;
        }
        public int StatusCode { get; set; }
        public IEnumerable<Error>? Errors { get; set; }
    }
}
