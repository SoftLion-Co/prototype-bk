using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public string Employment { get; set; }
        public byte[] Avatar { get; set; }
        public string Description { get; set; }
    }
}
