using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.AuthorDTO
{
    public class GetAuthorDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
