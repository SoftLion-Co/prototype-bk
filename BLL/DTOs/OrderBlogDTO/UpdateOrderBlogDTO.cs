using BLL.DTOs.Base;
using System;

namespace BLL.DTOs.OrderBlogDTO
{
    public class UpdateOrderBlogDTO : UpdateBaseDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string OrderType { get; set; } = null!;

    }
}
