using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Author : BaseEntity
    {
        public string Fullname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string LinkedIn { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Blog> Blogs { get; set; } = null!;

    }
}
