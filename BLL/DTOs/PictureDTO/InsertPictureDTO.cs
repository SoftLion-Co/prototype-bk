namespace BLL.DTOs.PictureDTO
{
    internal class InsertPictureDTO
    {
        public byte[] Content { get; set; } = null!;
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
