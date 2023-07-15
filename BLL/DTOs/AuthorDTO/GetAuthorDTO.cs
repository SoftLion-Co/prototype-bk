namespace BLL.DTOs.AuthorDTO
{
    public class GetAuthorDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Employment { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
