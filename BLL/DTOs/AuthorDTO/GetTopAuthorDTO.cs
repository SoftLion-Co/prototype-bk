namespace BLL.DTOs.AuthorDTO
{
    public class GetTopAuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!; 
        public string Employment { get; set; } = null!; 
        public string Avatar { get; set; } = null!; 
    }
}
