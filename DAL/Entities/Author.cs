using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Blog> Blogs { get; set; } = null!;

    }
}
