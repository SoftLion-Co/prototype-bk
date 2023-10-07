using System;
using System.Collections.Generic;

namespace BLL.DTOs.OrderBlogDTO
{
    public class InsertOrderBlogDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;

    }
}
