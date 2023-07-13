namespace DAL.Entities.ResponseEntity
{
    public class ResponseEntity<TResult>
    {
        public TResult? Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
