namespace BLL.DTOs.PictureDTO
{
    public class InsertPictureDTO
    {
        public byte[] Content { get; set; } = null!;
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
