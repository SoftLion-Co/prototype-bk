using BLL.DTOs.Base;

namespace BLL.DTOs.AuthorDTO
{
    public class UpdateAuthorDTO : UpdateBaseDTO
    {
        public string Fullname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string LinkedIn { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
