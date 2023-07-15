namespace BLL.DTOs.AuthorDTO
{
    public class GetAuthorDTO : BaseDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Employment { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
