using BLL.DTOs.Base;

namespace BLL.DTOs.PictureDTO
{
    public class UpdatePictureDTO : UpdateBaseDTO
    {
        public string Url { get; set; } = null!;
        //public Guid? BlogId { get; set; }
        //public Guid? ProjectId { get; set; }
    }
}
