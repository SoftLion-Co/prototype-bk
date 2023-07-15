namespace BLL.DTOs.RequestDTOs
{
    public class AuthorDTO : BaseDTO
    {
        public string FullName { get; set; }
        public string Employment { get; set; }
        public byte[] Avatar { get; set; }
        public string Description { get; set; }
    }
}
