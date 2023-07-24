using BLL.DTOs.Base;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.OrderProjectDTO
{
    public class GetOrderProjectDTO : GetBaseDTO
    {
        public string NumberPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string OrderType { get; set; } = null!;
    }
}
