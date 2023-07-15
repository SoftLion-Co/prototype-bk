namespace BLL.DTOs.AuthorDTO
{
    public class InsertAuthorDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
