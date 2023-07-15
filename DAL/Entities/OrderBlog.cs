using DAL.Entities.Base;
using DAL.Enums;

namespace DAL.Entities
{
    public class OrderBlog : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public OrderTypeEnum OrderType { get; set; }
    }
}
