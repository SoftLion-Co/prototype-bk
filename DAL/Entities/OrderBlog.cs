using DAL.Entities.Base;
using DAL.Enums;

namespace DAL.Entities
{
    public class OrderBlog : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public OrderTypeEnum OrderType { get; set; }
    }
}
