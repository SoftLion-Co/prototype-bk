using BLL.DTOs.Base;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.OrderBlogDTO
{
    public class GetOrderBlogDTO : GetBaseDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string OrderType { get; set; } = null!;
    }
}
