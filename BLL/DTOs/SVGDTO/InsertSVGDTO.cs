using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.SVG
{
    public class InsertSVGDTO
    {
        public IFormFile Url { get; set; } = null!;
        public Guid BlogId { get; set; }

    }
}
