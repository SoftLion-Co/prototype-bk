namespace BLL.DTOs
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
