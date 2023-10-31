using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.PictureDTO
{
    public class InsertPictureDTO
    {
        public IFormFile Url { get; set; } = null!;
        public int Position { get; set; }
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
