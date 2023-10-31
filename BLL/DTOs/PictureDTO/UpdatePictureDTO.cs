using BLL.DTOs.Base;
using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.PictureDTO
{
    public class UpdatePictureDTO : UpdateBaseDTO
    {
        public IFormFile Url { get; set; } = null!;
        public int Position { get; set; }
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
