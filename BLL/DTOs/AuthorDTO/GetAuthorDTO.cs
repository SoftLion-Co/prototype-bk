using BLL.DTOs.Base;

namespace BLL.DTOs.AuthorDTO
{
    public class GetAuthorDTO : GetBaseDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
