using BLL.DTOs.Base;

namespace BLL.DTOs.AuthorDTO
{
    public class GetTopAuthorDTO : GetTopBaseDTO
    {
        public string Name { get; set; } = null!; 
        public string Employment { get; set; } = null!; 
        public string Avatar { get; set; } = null!; 
    }
}
