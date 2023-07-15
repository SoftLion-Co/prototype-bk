using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Employment { get; set; } = string.Empty;
        public byte[] Avatar { get; set; } = null!;
        public string Description { get; set; } = string.Empty;

        public ICollection<Blog> Blogs { get; set; } = null!;

    }
}
