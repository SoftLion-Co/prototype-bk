using BLL.DTOs.Base;

namespace BLL.DTOs.PictureDTO
{
    public class GetPictureDTO : GetBaseDto
    {
        public string Url { get; set; } = null!;
        public int Position { get; set; }
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
