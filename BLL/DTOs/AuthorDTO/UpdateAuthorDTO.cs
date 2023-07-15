namespace BLL.DTOs.AuthorDTO
{
    public class UpdateAuthorDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
